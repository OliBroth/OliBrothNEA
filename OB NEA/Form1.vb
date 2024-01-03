'epicly shit
Imports System.Threading
Imports OB_NEA.Form1
Imports System.Collections.Generic
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar
Imports System.Windows.Forms.AxHost
Imports System.Text.Json
Imports System.Windows.Forms.VisualStyles

Public Class Form1
    'drawing form with its controllers
    Private Const psize As Integer = 3
    Private m As Integer = 3
    Private mazeimage As Bitmap
    Private MazeGraphics As Graphics
    Private mazeColour As Color = Color.Black

    Private random As New Random() 'randomises number
    Private maze As Cell(,)

    Private width, height As Integer
    Private mentry, mexit As Point
    Private deadEnd As New List(Of Point)
    Private mwallcount As Integer = 0
    Private totalcells As Integer = 0


    Private passedPath As New List(Of Point)
    Dim path As New Queue(Of Point)()
    Public cancelAnimation As Boolean = False
    Public resetType As String
    Private mazegen As Boolean = False
    'in dfs
    Dim genstack As New Stack(Of Point)


    'astar/dijkstra
    Dim gweight As New Dictionary(Of Point, Double)
    Dim solvi As New Queue(Of Point)



    Private genrationAlgorithm As String 'test value
    'time variable
    Private solveTimer As New Stopwatch
    Private generationTimer As New Stopwatch
    Private drawTimer As New Stopwatch

    'astar
    Public Class AStarNode
        Public Property Location As Point
        Public Property G As Double ' Cost from the start node
        Public Property H As Double ' Heuristic value
        Public Property F As Double ' Total cost (G + H)
        Public Property Parent As AStarNode

    End Class
    'dijkstra
    Public Class Node
        Public Property Location As Point
        Public Property g As Double
        Public Property Parent As Node

        Public Sub New(location As Point)
            Me.Location = location
            Me.g = Double.PositiveInfinity
            Me.Parent = Nothing
        End Sub
    End Class
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.



        AddHandler GenBtn.Click, AddressOf GenBtn_Click
        '    AddHandler SolBtn.Click, AddressOf solBtn_Click

        '    AddHandler mSaveBtn.Click, AddressOf mSaveBtn_click

    End Sub
    Public Class PriorityQueue(Of priority As IComparable, value)
        Private ReadOnly dictionary As SortedDictionary(Of priority, Queue(Of value))

        Public Sub Enqueue(priority As priority, value As value)
            ' If we have a new priority we create a new queue
            If Not dictionary.ContainsKey(priority) Then
                dictionary(priority) = New Queue(Of value)()
            End If
            ' Add value to queue
            dictionary(priority).Enqueue(value)
        End Sub
        Public Function Dequeue() As value
            ' This helps when debugging
            If dictionary.Count = 0 Then
                Throw New InvalidOperationException("The priority queue is empty.")
            End If

            Dim pair1 As KeyValuePair(Of priority, Queue(Of value)) = dictionary.First()
            Dim value As value = pair1.Value.Dequeue()

            If pair1.Value.Count = 0 Then
                dictionary.Remove(pair1.Key)
            End If

            Return value
        End Function

        ' Checks if the whole queue is empty
        Public Function isEmpty() As Boolean
            Return dictionary.Count = 0
        End Function
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("hello world")




    End Sub
    Private Sub InitializeMaze()
        ' Resets old timer, Starts new timer, Updates Status
        statusLbl.Text = "Status: Initializing Maze"
        statusLbl.Update()

        ' Initialize each cell with correct: Type and Wall Position
        maze = New Cell(width, height) {}
        mazeimage = New Bitmap(((width + 1) * m) + m, ((height + 1) * m) + m)
        MazeGraphics = Graphics.FromImage(mazeimage)

        For i As Integer = 0 To width
            For j As Integer = 0 To height
                ' Giving each cell their index
                maze(i, j) = New Cell With {.x = i, .y = j}

                ' Setting the maze wall cells with the mazeWallBool
                If i = 0 Or j = 0 Or i = width Or j = height Then
                    With maze(i, j)
                        .mwallbool = True
                        .visited = True
                        mwallcount += 1
                    End With
                Else
                    totalcells += 1
                End If

                ' Calculate cell positions outside the loop
                Dim posi As Integer = i * m
                Dim posj As Integer = j * m

                ' Giving each cell wall a start(0), end(1) and position on the screen
                For Each wall In maze(i, j).walls
                    Select Case wall
                        Case 0 ' Top Wall
                            With maze(i, j)
                                .wallpos(0, 0) = New Point(posi, posj)
                                .wallpos(0, 1) = New Point(posi + m, posj)
                            End With
                        Case 1 ' Right Wall
                            With maze(i, j)
                                .wallpos(1, 0) = New Point(posi + m, posj)
                                .wallpos(1, 1) = New Point(posi + m, posj + m)
                            End With
                        Case 2 ' Bottom Wall
                            With maze(i, j)
                                .wallpos(2, 0) = New Point(posi, posj + m)
                                .wallpos(2, 1) = New Point(posi + m, posj + m)
                            End With
                        Case 3 ' Left Wall
                            With maze(i, j)
                                .wallpos(3, 0) = New Point(posi, posj)
                                .wallpos(3, 1) = New Point(posi, posj + m)
                            End With
                    End Select
                Next
            Next
        Next


        ' Setting Maze Entry and Exit
        mEntryExit()
    End Sub
    Private Sub mEntryExit()
        Randomize()
        'random protection will repeat if start and finish point are the same
        Do
            Dim randomType As Integer = random.Next(0, 4)

            ' Start and finish positions for each random type
            Dim entryX, entryY, exitX, exitY As Integer

            Select Case randomType
                Case 0, 1 ' Start at a random top or bottom position
                    entryX = random.Next(1, width)
                    entryY = If(randomType = 0, 1, height - 1)
                    exitX = random.Next(1, width)
                    exitY = If(randomType = 0, height - 1, 1)
                Case 2, 3 ' Start at a random right or left position
                    entryX = If(randomType = 2, 1, width - 1)
                    entryY = random.Next(1, height)
                    exitX = If(randomType = 2, width - 1, 1)
                    exitY = random.Next(1, height)
            End Select

            mentry = New Point(entryX, entryY)
            mexit = New Point(exitX, exitY)
        Loop While mentry = mexit

        ' Setting the entry cell with the mentrybool
        With maze(mentry.X, mentry.Y)
            .maentrybool = True
            .mwallbool = False

        End With

        ' Setting the exit cell with the mexitbool
        With maze(mexit.X, mexit.Y)
            .mexitbool = True
            .mwallbool = False
        End With
    End Sub
    Private Sub drawMaze()
        drawTimer.Reset()
        drawTimer.Start()
        statusLbl.Text = "Status: Drawing Maze"
        statusLbl.Update()
        Using bbrush As New SolidBrush(Color.White)
            Using mazeBrush As New SolidBrush(Color.Black)
                Using solBrush As New SolidBrush(Color.Fuchsia)
                    Using enBrush As New SolidBrush(Color.Green)
                        Using exBrush As New SolidBrush(Color.Red)
                            For Each cell In maze
                                ' Determine the fill color based on cell properties
                                Dim fillBrush As Brush = bbrush
                                If cell.mwallbool Then
                                    fillBrush = mazeBrush
                                End If
                                If cell.maentrybool Then
                                    fillBrush = enBrush
                                End If
                                If cell.mexitbool Then
                                    fillBrush = exBrush
                                End If
                                If cell.msol Then
                                    fillBrush = solBrush
                                End If

                                ' Draw the cell background and fill
                                MazeGraphics.FillRectangle(fillBrush, cell.wallpos(0, 0).X, cell.wallpos(1, 0).Y, m, m)

                                ' Draw the walls
                                cell.drawWalls()
                            Next
                        End Using
                    End Using
                End Using
            End Using
        End Using
        drawTimer.stop()
    End Sub
    Private Sub reset()
        solvi.Clear()
        path.clear()

    End Sub
    Public Class Cell
        Public x, y As Integer
        Public walls As New List(Of Boolean)({True, True, True, True})
        Public wallpos(3, 1) As Point
        'type cell
        Public mwallbool As Boolean = False
        Public maentrybool As Boolean = False
        Public mexitbool As Boolean = False
        Public msol As Boolean = False
        'gen/sol properties
        Public visited As Boolean = False
        Public concell As New List(Of Point)
        Public Sub drawWalls()
            For wall As Integer = 0 To 3
                If walls(wall) = True And Form1.mazeColour = Color.Empty Then
                    Form1.MazeGraphics.DrawLine(New Pen(Color.Black, psize), wallpos(wall, 0), wallpos(wall, 1))
                    Form1.MazeGraphics.DrawLine(New Pen(Color.Black, psize), wallpos(wall, 0), wallpos(wall, 1))
                ElseIf walls(wall) = True Then ' If user hasnt selected colour
                    Form1.MazeGraphics.DrawLine(New Pen(Form1.mazeColour, psize), wallpos(wall, 0), wallpos(wall, 1))
                    Form1.MazeGraphics.DrawLine(New Pen(Form1.mazeColour, psize), wallpos(wall, 0), wallpos(wall, 1))
                End If
            Next
        End Sub
      Public Function removeWall(ByVal d As Integer)
            Dim directions As Point() = {New Point(0, -1), New Point(1, 0), New Point(0, 1), New Point(-1, 0)}

            If mwallbool = True Then
                Return Point.Empty
            End If

            ' Calculate the new coordinates based on the chosen direction (d)
            Dim nx As Integer = x + directions(d).X
            Dim ny As Integer = y + directions(d).Y

            ' Check if the new coordinates are within the bounds of the maze
            If nx >= 0 AndAlso nx < Form1.maze.GetLength(0) AndAlso ny >= 0 AndAlso ny < Form1.maze.GetLength(1) AndAlso Form1.maze(nx, ny).mwallbool = True Then
                Return Point.Empty 'failure case
            End If

            ' Disable the current direction's wall and the opposite direction's wall in the neighboring cell
            walls(d) = False
            Form1.maze(nx, ny).walls((d + 2) Mod 4) = False

            ' Add the current cell's coordinates to the list of connected cells
            concell.Add(New Point(nx, ny))

            ' Add the current cell's coordinates to the list of connected cells in the neighboring cell
            Form1.maze(nx, ny).concell.Add(New Point(x, y))

            ' Return the last added coordinates in the list of connected cells
            Return concell(concell.Count() - 1)
        End Function
        'to get unvisited neighbours
        Function GetUnvisitedNeighbours(rand As Boolean) As List(Of Point)

            Dim neighbours As New List(Of Point)
            Dim directions As Point() = {New Point(0, -1), New Point(1, 0), New Point(0, 1), New Point(-1, 0)}

            If mwallbool = True Then
                Return neighbours
            End If

            For Each direction In directions
                Dim nx As Integer = x + direction.X
                Dim ny As Integer = y + direction.Y

                If nx >= 0 AndAlso nx < Form1.maze.GetLength(0) AndAlso ny >= 0 AndAlso ny < Form1.maze.GetLength(1) AndAlso Form1.maze(nx, ny).visited = False Then
                    neighbours.Add(New Point(nx, ny))
                Else
                    neighbours.Add(Point.Empty) 'failure case
                End If
            Next

            ' Shuffle the neighbours list randomly only required by walkrandomly
            If rand = True Then
                neighbours = Shuffle(neighbours)
            End If
            Return neighbours
        End Function

        Function Shuffle(Of T)(ByVal list As List(Of T)) As List(Of T)
            Dim rand As New Random()
            Dim n As Integer = list.Count

            While n > 1
                n -= 1
                Dim k As Integer = rand.Next(n + 1)
                Dim value As T = list(k)
                list(k) = list(n)
                list(n) = value
            End While

            Return list
        End Function

    End Class

    Private Sub DFS(ByVal x As Integer, ByVal y As Integer)
        ' Initialize the stack with the starting point
        genstack.Push(New Point(x, y))

        Dim direction As Integer

        ' Loop until the stack is empty
        While genstack.Count > 0

            Dim currentCell = genstack.Peek()
            Dim cell = maze(currentCell.X, currentCell.Y)

            ' Mark the current cell as visited
            cell.visited = True

            ' Get the unvisited neighbors of the current cell
            Dim unvisitedNeighbours = cell.GetUnvisitedNeighbours(False)

            ' If all neighbors are visited, pop another cell from the stack and continue the loop
            If unvisitedNeighbours.All(Function(p) p.Equals(Point.Empty)) = True Then
                genstack.Pop()
                Continue While
            End If

            ' Filter out the empty values from the list of neighbors
            Dim validNeighbours = unvisitedNeighbours.Where(Function(point) point <> Point.Empty).ToList()

            ' Randomly choose a valid direction from the list of non-empty neighbors
            Randomize()
            direction = unvisitedNeighbours.IndexOf(validNeighbours(random.Next(0, validNeighbours.Count())))


            If unvisitedNeighbours.Count > 0 Then

                Dim neighbours = cell.removeWall(direction)
                genstack.Push(neighbours)

            End If
        End While
    End Sub

    Private Sub HuntAndKill(width, height)
        ' create an empty maze
        Dim maze(width - 1, height - 1) As Boolean

        ' Start at a random cell
        Dim currentCell = RandomCellInMaze(width, height, random)

        While currentCell > 0
            ' Walk randomly through the maze
            WalkRandomly(currentCell)
            Dim cell = maze(currentCell.X, currentCell.Y)
            ' Hunt for an unvisited cell
            currentCell = HuntForUnvisitedCell(maze, random, cell)
        End While
    End Sub ' no issues yet
    Function WalkRandomly(currentcell)
        Dim direction As Integer
        While currentcell > 0
            Dim cell = maze(currentcell.X, currentcell.Y)
            ' Mark the current cell as visited
            cell.visited = True

            ' Get a random unvisited neighbor
            Dim neighbourcell = cell.GetUnvisitedNeighbours(True) 'randomisation as rand is set to true

            If neighbourcell.Count > 0 Then
                ' Remove the wall between the current cell and the neighbor
                cell.removeWall(direction)

                ' Update the current cell
                currentcell = neighbourcell
            Else
                ' Dead end reached
                Exit While
            End If
        End While
    End Function

    Function HuntForUnvisitedCell(ByRef maze As Boolean(,), ByVal random As Random, ByVal cell As Object)
        Dim unvisitedNeighbour As Point = Point.Empty

        For x As Integer = 0 To maze.GetLength(0) - 1
            For y As Integer = 0 To maze.GetLength(1) - 1
                If Not maze(x, y) Then
                    ' The cell is unvisited
                    unvisitedNeighbour = cell.GetUnvisitedNeighbours(True) 'randomisation as rand is set to true

                    ' Remove the wall between the cell and its unvisited neighbor
                    cell.RemoveWall(unvisitedNeighbour, maze)

                    ' Return the unvisited neighbor
                    Return unvisitedNeighbour
                End If
            Next
        Next

        ' No unvisited cell found
        Return Point.Empty
    End Function

    Sub MarkCurrentCellAsVisited(ByRef currentCell As Point, ByRef maze As Boolean(,))
        maze(currentCell.X, currentCell.Y) = True
    End Sub
    Function HasUnvisitedNeighbour(ByRef currentCell As Point, ByRef maze As Boolean(,), ByVal random As Random) As Boolean
        ' Create a list to store potential neighbors
        Dim potentialNeighbors As New List(Of Point)

        ' Check top neighbour
        If currentCell.X > 0 AndAlso Not maze(currentCell.X - 1, currentCell.Y) Then
            potentialNeighbors.Add(New Point(currentCell.X - 1, currentCell.Y))
        End If

        ' Check bottom neighbour
        If currentCell.X < maze.GetLength(0) - 1 AndAlso Not maze(currentCell.X + 1, currentCell.Y) Then
            potentialNeighbors.Add(New Point(currentCell.X + 1, currentCell.Y))
        End If

        ' Check left neighbour  
        If currentCell.Y > 0 AndAlso Not maze(currentCell.X, currentCell.Y - 1) Then
            potentialNeighbors.Add(New Point(currentCell.X, currentCell.Y - 1))
        End If

        ' Check right neighbor
        If currentCell.Y < maze.GetLength(1) - 1 AndAlso Not maze(currentCell.X, currentCell.Y + 1) Then
            potentialNeighbors.Add(New Point(currentCell.X, currentCell.Y + 1))
        End If

        ' Shuffle the potential neighbors to introduce randomness
        potentialNeighbors = potentialNeighbors.OrderBy(Function() random.Next()).ToList()

        ' Check if there are unvisited neighbors
        Return potentialNeighbors.Any()
    End Function

    Function RandomCellInMaze(ByVal x As Integer, ByVal y As Integer, ByVal random As Random)
        ' Implement logic to get a random cell in the maze

        ' Placeholder logic 
        Dim randx As Integer = random.Next(x)
        Dim randy As Integer = random.Next(y)

        Return New Point(randx, randy)
    End Function
    Private Sub generationPointTimer_Tick(sender As Object, e As EventArgs) Handles gentimer.Tick


        If genrationAlgorithm = "DFS Backtracker" Then
            If genstack.Count > 0 Then
                Dim currentCell = genstack.Peek()
                Dim cell = maze(currentCell.X, currentCell.Y)

                ' Highlight the top of the stack
                If currentCell <> mentry And currentCell <> mexit Then
                    MazeGraphics.FillRectangle(New SolidBrush(Color.Yellow), currentCell.X * m, currentCell.Y * m, m, m)
                    maze(currentCell.X, currentCell.Y).drawWalls()
                End If


                ' Mark current cell as visited
                cell.visited = True

                ' Get a list of unvisited neighbors
                Dim unvisitedNeighbours = cell.GetUnvisitedNeighbours(False)

                If unvisitedNeighbours.All(Function(p) p.Equals(Point.Empty)) = True Then
                    genstack.Pop()
                Else
                    ' Make a new list that only contains the non empty values from neighbour
                    Dim validNeigbours As New List(Of Point)
                    For Each point In unvisitedNeighbours
                        If point <> point.Empty Then
                            validNeigbours.Add(point)
                        End If
                    Next

                    ' Randomly pick a valid neighbour. Find the index of that point within the orginal neighbour list and set that to direction
                    Dim direction = unvisitedNeighbours.IndexOf(validNeigbours(random.Next(0, validNeigbours.Count())))

                    ' Break the wall between the current cell and the chosen neighbor
                    Dim randomNeighbor = cell.removeWall(direction)

                    ' Add the neighbor to the stack
                    genstack.Push(randomNeighbor)
                End If

                ' Update the maze and the maze display
                PictureBox1.Image = mazeimage
                PictureBox1.Update()

                ' Resrt the top of the stack
                If currentCell <> mentry And currentCell <> mexit Then
                    MazeGraphics.FillRectangle(New SolidBrush(Color.White), currentCell.X * m, currentCell.Y * m, m, m)
                    maze(currentCell.X, currentCell.Y).drawWalls()
                End If
            Else
                drawMaze()
                ' Update the maze and the maze display
                PictureBox1.Image = mazeimage
                PictureBox1.Update()


                ' Stop the timer when the maze is complete
                gentimer.Enabled = False
            End If

        Else
            drawMaze()
            ' Update the maze and the maze display
            PictureBox1.Image = mazeimage
            PictureBox1.Update()


            ' Stop the timer when the maze is complete
            gentimer.Enabled = False
        End If






    End Sub

    'solving
    '2 error

    Function ReconstructPath(node) As Queue(Of Point)

        While node > 0
            path.Enqueue(node.Location)
            node = node.Parent
        End While

        path.Reverse()
        Return path
    End Function
    Private Function CalculateManhattanDistance(point1 As Point, point2 As Point) As Double
        Return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y)
    End Function
    Private Function Distance(point1 As Point, point2 As Point) As Double
        Return Math.Sqrt((point1.X - point2.X) ^ 2 + (point1.Y - point2.Y) ^ 2)
    End Function



    Private Function GetNeighbours(location As Point) As List(Of Point)
        Dim neighbours As New List(Of Point)()

        ' Define the possible directions (north, south, east, west)
        Dim directions As Point() = {
        New Point(0, -1), ' North
        New Point(0, 1),  ' South
        New Point(-1, 0), ' West
        New Point(1, 0)   ' East
    }

        ' Check each direction to find neighbours
        For Each direction In directions
            Dim neighbour As New Point(location.X + direction.X, location.Y + direction.Y)
            neighbours.Add(neighbour)
        Next

        Return neighbours
    End Function


    'USER INPUT FROM HERE ON
    Private Sub GenBtn_Click(sender As Object, e As EventArgs) Handles GenBtn.Click
        ' Saves Maze Properties inputted by the user
        ' Checking that the values inputted for width and height are valid
        If Integer.TryParse(widthTxtBox.Text, width) AndAlso width > 2 AndAlso Integer.TryParse(heightTxtBox.Text, height) AndAlso height > 2 Then
            width -= 1
            height -= 1
        Else
            MsgBox("Make sure width and height are integers greater than 3", MsgBoxStyle.OkOnly, "Invalid Input")
            Exit Sub
        End If

        Dim multiplier As Integer = Math.Floor(Math.Min(1220 / width, 690 / height))
        If multiplier < 3 Then
            MsgBox("ERROR: WIDTH >406 AND/OR HEIGHT >230" & vbCrLf & "Want to download maze?" & vbCrLf & "WARNING! DEPENDING ON HARDWARE THIS MAY TAKE A LONG TIME", MsgBoxStyle.OkCancel)
        Else

            m = multiplier
        End If

        ' Initializes the maze
        InitializeMaze()
        ' Allows the program to know whether or not a maze has been generated
        mazegen = True

        ' Resets old timer, Starts new timer, Updates Status
        UpdateStatusLabel("Generating")
        ' Resets old timer, Starts new timer, Upates Status
        statusLbl.Text = "Status: Generating"
        statusLbl.Update()

        gentimer.Start()
        ' Checks what generation algorithm the user has chosen
        Select Case generationCombo.Text
            Case "DFS "
                DFS(random.Next(1, width), random.Next(1, height))
            Case "Hunt & Kill "
                HuntAndKill(random.Next(1, width), random.Next(1, height))
        End Select
        gentimer.Stop()
        ' Draws the generated maze
        drawMaze()
        PictureBox1.Image = mazeimage
        gentimelbl.Text = "Generation Time: " & Str(generationTimer.ElapsedMilliseconds() / 1000) & "s"
        ' Resets Status, ' Resets Dialog Result
        UpdateStatusLabel("Doing Nothing")
    End Sub

    Private Sub UpdateStatusLabel(ByVal status As String)
        statusLbl.Text = "Status: " & status
        statusLbl.Update()

    End Sub
    Private Sub savemaze()
        If mazegen = True Then
            Dim openfile As New SaveFileDialog
            openfile.FileName = Nothing
            openfile.Filter = "JPG File's |*.jpg"
            openfile.ShowDialog()
        End If
    End Sub
    Private Sub mSaveBtn_click(sender As Object, e As EventArgs)
        savemaze()
    End Sub
End Class
