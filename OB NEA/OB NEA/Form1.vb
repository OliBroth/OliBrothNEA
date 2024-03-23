'DOA 13:59 23/03/2024
Imports System.Threading
Imports OB_NEA.Form1
Imports System.Collections.Generic
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar
Imports System.Windows.Forms.AxHost
Imports System.Text.Json
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class Form1
    'drawing form with its controllers
    Private Const psize As Integer = 2
    Private m As Integer = 3
    Private mazeimage As Bitmap
    Private MazeGraphics As Graphics
    Private mazeColour As Color = Color.Black

    Private random As New Random() 'randomises number
    Private maze As Cell(,)

    Private width, height As Integer
    Private mentry, mexit As Point
    Private mapmodepercent As Double
    Private deadEnd As New List(Of Point)
    Private entryexit As String
    Private mwallcount As Integer = 0
    Private totalcells As Integer = 0

    Private azure As Color = Color.FromArgb(0, 127, 255)
    Private steel As Color = Color.FromArgb(242, 133, 0) 'tangerine
    Private passedPath As New List(Of Point)
    Dim path As New Queue(Of Point)()
    Public cancelAnimation As Boolean = False
    Public resetType As String
    Private mazegen As Boolean = False
    'in dfs
    Dim genstack As New Stack(Of Point)
    'hk
    Private huntTargets As New List(Of Point)


    'astar/dijkstra
    Public gweight As New Dictionary(Of Point, Double)
    Private closedset As New Queue(Of Point)
    Private maxweight As Integer
    Private G As Double ' Cost from the start node
    Private H As Double ' Heuristic value
    Private F As Double ' Total cost (G + H)
    Private solvealgorithm, generationAlgorithm As String 'test value
    'time variable
    Private solveTimer As New Stopwatch
    Private generationtimer As New Stopwatch
    Private drawTimer As New Stopwatch


    Public Sub New()

        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.


        AddHandler GenBtn.Click, AddressOf GenBtn_Click
        AddHandler SolBtn.Click, AddressOf solBtn_Click
        AddHandler mapmodebtn.Click, AddressOf mapmodebtn_click
        AddHandler gentimer.Tick, AddressOf gentimer_tick
        AddHandler solvedpathtimer.Tick, AddressOf solvpath_tick
        AddHandler searchtimer.Tick, AddressOf searchanimation_tick
        AddHandler mSaveBtn.Click, AddressOf mSaveBtn_click
        AddHandler cnclanimation.Click, AddressOf cnclanimation_click
        AddHandler PictureBox3.Click, AddressOf PictureBox3_Click

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        widthTxtBox.Text = 25
        heightTxtBox.Text = 25
        entryexitcombo.SelectedIndex = 0 ' Default displays "Random"
        cnclanimation.Enabled = False

    End Sub

    Public Class PriorityQueue(Of priority As IComparable, value)
        Private ReadOnly dictionary As SortedDictionary(Of priority, Queue(Of value))
        Public Sub New()
            ' This assigns the items in the dictionary
            dictionary = New SortedDictionary(Of priority, Queue(Of value))()
        End Sub

        Public Sub Enqueue(priority As priority, val As value)
            ' If we have a new priority we create a new queue
            If Not dictionary.ContainsKey(priority) Then
                dictionary(priority) = New Queue(Of value)()
            End If
            ' Add value to queue
            dictionary(priority).Enqueue(val)
        End Sub
        Public Function Dequeue() As value
            ' This helps when debugging
            If dictionary.Count = 0 Then
                Throw New InvalidOperationException("The priority queue is empty.")
            End If

            Dim pair1 As KeyValuePair(Of priority, Queue(Of value)) = dictionary.First()
            Dim val As value = pair1.Value.Dequeue()

            If pair1.Value.Count = 0 Then
                dictionary.Remove(pair1.Key)
            End If

            Return val
        End Function

        ' Checks if the whole queue is empty
        Public Function isEmpty() As Boolean
            Return dictionary.Count = 0
        End Function

        Public Function Count() As Integer
            Dim totalCount As Integer = 0
            For Each p In dictionary.Values
                totalCount += p.Count
            Next
            Return totalCount
        End Function

        Public Function Contains(val As value) As Boolean
            For Each p In dictionary.Values
                If p.Contains(val) Then
                    Return True
                End If
            Next
            Return False
        End Function

    End Class

    Private Sub InitializeMaze()

        ' Resets old timer, Starts new timer, Updates Status
        UpdateStatusLabel("Initializing Maze")


        ' Initialize each cell with correct Type, Wall Position, 
        maze = New Cell(width, height) {}
        mazeimage = New Bitmap(((width + 1) * m) + m, ((height + 1) * m) + m)
        MazeGraphics = Graphics.FromImage(mazeimage)

        For i As Integer = 0 To width
            For j As Integer = 0 To height
                maze(i, j) = New Cell With {.x = i, .y = j}

                If i = 0 Or j = 0 Or i = width Or j = height Then
                    maze(i, j).mwallbool = True
                    maze(i, j).visited = True
                    mwallcount += 1
                Else
                    totalcells += 1
                End If

                ' Calculate cell positions
                Dim posi As Integer = i * m
                Dim posj As Integer = j * m
                For Each wall In maze(i, j).walls
                    ' Giving each cell wall a start(0), end(1) and position on the screen
                    maze(i, j).wallpos(0, 0) = New Point(posi, posj)
                    maze(i, j).wallpos(0, 1) = New Point(posi + m, posj)
                    maze(i, j).wallpos(1, 0) = New Point(posi + m, posj)
                    maze(i, j).wallpos(1, 1) = New Point(posi + m, posj + m)
                    maze(i, j).wallpos(2, 0) = New Point(posi, posj + m)
                    maze(i, j).wallpos(2, 1) = New Point(posi + m, posj + m)
                    maze(i, j).wallpos(3, 0) = New Point(posi, posj)
                    maze(i, j).wallpos(3, 1) = New Point(posi, posj + m)
                Next
            Next
        Next

        ' Setting Maze Entry and Exit
        mEntryExit()
    End Sub
    Private Sub mEntryExit()
        'random protection will repeat if start and finish point are the same
        Do


            ' Start and finish positions for each random type
            Dim entryX, entryY, exitX, exitY As Integer
            Select Case entryexit
                Case "Random"
                    Randomize()
                    Dim randomType As Integer = random.Next(0, 6)
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
                        Case 4
                            entryX = width \ 2
                            entryY = height \ 2
                            Dim randomSide As Integer = random.Next(1, 5) ' Randomly select top, bottom, left, or right

                            Select Case randomSide
                                Case 1 ' Top side
                                    exitX = random.Next(1, width)
                                    exitY = 1
                                Case 2 ' Bottom side
                                    exitX = random.Next(1, width)
                                    exitY = height - 1
                                Case 3 ' Left side
                                    exitX = 1
                                    exitY = random.Next(1, height)
                                Case 4 ' Right side
                                    exitX = width - 1
                                    exitY = random.Next(1, height)
                            End Select
                        Case 5
                            exitX = width \ 2
                            exitY = height \ 2
                            Dim randomSide As Integer = random.Next(1, 5) ' Randomly select top, bottom, left, or right entry

                            Select Case randomSide
                                Case 1 ' Top side
                                    entryX = random.Next(1, width)
                                    entryY = 1
                                Case 2 ' Bottom side
                                    entryX = random.Next(1, width)
                                    entryY = height - 1
                                Case 3 ' Left side
                                    entryX = 1
                                    entryY = random.Next(1, height)
                                Case 4 ' Right side
                                    entryX = width - 1
                                    entryY = random.Next(1, height)
                            End Select
                    End Select
                Case "Labyrinth" 'start centre exit out
                    entryX = width \ 2
                    entryY = height \ 2
                    Dim randomSide As Integer = random.Next(1, 5) ' Randomly select top, bottom, left, or right exit 

                    Select Case randomSide
                        Case 1 ' Top side
                            exitX = random.Next(1, width)
                            exitY = 1
                        Case 2 ' Bottom side
                            exitX = random.Next(1, width)
                            exitY = height - 1
                        Case 3 ' Left side
                            exitX = 1
                            exitY = random.Next(1, height)
                        Case 4 ' Right side
                            exitX = width - 1
                            exitY = random.Next(1, height)
                    End Select
                Case "Labyrinth 2"
                    exitX = width \ 2
                    exitY = height \ 2
                    Dim randomSide As Integer = random.Next(1, 5) ' Randomly select top, bottom, left, or right entry

                    Select Case randomSide
                        Case 1 ' Top side
                            entryX = random.Next(1, width)
                            entryY = 1
                        Case 2 ' Bottom side
                            entryX = random.Next(1, width)
                            entryY = height - 1
                        Case 3 ' Left side
                            entryX = 1
                            entryY = random.Next(1, height)
                        Case 4 ' Right side
                            entryX = width - 1
                            entryY = random.Next(1, height)
                    End Select
                Case "Top/Bottom"
                    Dim randomType As Integer = random.Next(0, 4)
                    entryX = random.Next(1, width)
                    entryY = If(randomType = 0, 1, height - 1)
                    exitX = random.Next(1, width)
                    exitY = If(randomType = 0, height - 1, 1)
                Case "Left/Right"
                    Dim randomType As Integer = random.Next(0, 4)
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
        UpdateStatusLabel("Drawing Maze")

        Using bbrush As New SolidBrush(Color.White)
            Using mazeBrush As New SolidBrush(Color.Black)
                Using solBrush As New SolidBrush(Color.RebeccaPurple)
                    Using enBrush As New SolidBrush(Color.Green)
                        Using exBrush As New SolidBrush(Color.Red)
                            For Each cell In maze
                                ' Determine the fill colour based on cell properties
                                Dim fillBrush As Brush = bbrush
                                If cell.mwallbool = True Then
                                    fillBrush = mazeBrush
                                End If
                                If cell.maentrybool = True Then
                                    fillBrush = enBrush
                                End If
                                If cell.mexitbool = True Then
                                    fillBrush = exBrush
                                End If
                                If cell.msolv = True Then
                                    fillBrush = solBrush
                                End If

                                ' Draw the cell background and fill
                                MazeGraphics.FillRectangle(fillBrush, cell.wallpos(0, 0).X, cell.wallpos(1, 0).Y, m, m)

                                ' Draw the walls
                                cell.drawWalls()
                            Next
                            'stop drawing
                        End Using
                    End Using
                End Using
            End Using
        End Using
        drawTimer.Stop()

    End Sub

    Private Sub reset()

        closedset.Clear()
        path.Clear()
        passedPath.Clear()

        ' Reset the mazeSolved property for each cell
        For x As Integer = 0 To width - 1
            For y As Integer = 0 To height - 1
                maze(x, y).msolv = False
            Next
        Next
        If resetType = "G" Then
            If generationAlgorithm = "DFS " Then

                DFS(random.Next(1, width), random.Next(1, height))

            ElseIf generationAlgorithm = "Hunt And Kill" Then

                HK(random.Next(1, width), random.Next(1, height))
            End If
        ElseIf resetType = "S" Then

            If solvealgorithm = "Dijkstra's" Then
                Dijkstra()
            End If
        ElseIf solvealgorithm = "A* " Then
            astar()
        End If
        drawMaze()
        PictureBox1.Image = mazeimage
        PictureBox1.Update()
        animationbtn.Checked = False

    End Sub
    Private Sub backloggprotect(yes As Boolean)

        If yes = True Then
            'buttons
            GenBtn.Enabled = False
            SolBtn.Enabled = False
            mSaveBtn.Enabled = False
            mColBtn.Enabled = False
            sColBtn.Enabled = False
            cnclanimation.Enabled = True

            'combo boxes
            generationCombo.Enabled = False
            solveCombo.Enabled = False
            'txt boxes
            widthTxtBox.Enabled = False
            heightTxtBox.Enabled = False
        ElseIf yes = False Then
            'buttons
            GenBtn.Enabled = True
            SolBtn.Enabled = True
            mSaveBtn.Enabled = True
            mColBtn.Enabled = True
            sColBtn.Enabled = True
            cnclanimation.Enabled = False

            'combo boxes
            generationCombo.Enabled = True
            solveCombo.Enabled = True
            'txt boxes
            widthTxtBox.Enabled = True
            heightTxtBox.Enabled = True
            Exit Sub
        End If

    End Sub
    Public Class Cell

        Public x, y As Integer
        Public walls As New List(Of Boolean)({True, True, True, True})
        Public wallpos(3, 1) As Point
        'type cell
        Public mwallbool As Boolean = False
        Public maentrybool As Boolean = False
        Public mexitbool As Boolean = False
        Public msolv As Boolean = False
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

        Public Sub mapwallpos()

            Dim countwall As Integer = 0
            If mwallbool = False Then
                For Each wall In walls
                    If wall = True Then
                        countwall += 1
                        If countwall = 3 Then
                            Exit For
                        End If
                    End If
                Next
            End If
            If countwall = 3 AndAlso Not Form1.deadEnd.Contains(New Point(x, y)) Then
                Form1.deadEnd.Add(New Point(x, y))
            End If

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
                Return {Point.Empty, Point.Empty, Point.Empty, Point.Empty}.ToList
                Exit Function
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

            ' Shuffle the neighbours list 
            If rand = True Then
                neighbours = Shuffle(neighbours)
                Return neighbours
            End If
            Return neighbours

        End Function

        Private Function Shuffle(neighbours) 'doesnt work 

            If mwallbool = True Then
                Return {Point.Empty, Point.Empty, Point.Empty, Point.Empty}.ToList
                Exit Function
            End If
            Dim rand As New Random()
            Dim n As Integer = neighbours.Count
            While n > 1
                n -= 1
                Dim k As Integer = rand.Next(n + 1)
                Dim value As Point = neighbours(k)
                neighbours(k) = neighbours(n)
                neighbours(n) = value
            End While

        End Function
        Function GetDirectionTo(ByVal currentCell As Point, ByVal nextCell As Point) As Integer

            Dim dx As Integer = nextCell.X - currentCell.X
            Dim dy As Integer = nextCell.Y - currentCell.Y

            If dx = 1 AndAlso dy = 0 Then
                Return 0 ' Right
            ElseIf dx = -1 AndAlso dy = 0 Then
                Return 1 ' Left
            ElseIf dx = 0 AndAlso dy = 1 Then
                Return 2 ' Down
            ElseIf dx = 0 AndAlso dy = -1 Then
                Return 3 ' Up
            Else
                Throw New ArgumentException("Cells are not adjacent.")
            End If

        End Function

    End Class

    Private Sub DFS(ByVal x As Integer, ByVal y As Integer)

        ' Initialize the stack with the starting point
        genstack.Push(New Point(x, y))


        If animationbtn.Checked = True Then
            backloggprotect(True)
            gentimer.Enabled = True

        Else
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
                Dim valNeighbours = unvisitedNeighbours.Where(Function(p) p <> Point.Empty).ToList()

                ' Randomly choose a valid direction from the list of non-empty neighbors
                Randomize()
                direction = unvisitedNeighbours.IndexOf(valNeighbours(random.Next(0, valNeighbours.Count())))


                Dim neighbours = cell.removeWall(direction)
                genstack.Push(neighbours)
            End While
        End If

    End Sub

    Private Sub HK(ByVal x As Integer, ByVal y As Integer)

        ' Initialize the stack with the starting point
        genstack.Push(New Point(x, y))

        Dim direction As Integer
        Dim huntMode As Boolean = False ' Flag to indicate whether the algorithm is in hunt mode

        If animationbtn.Checked = True Then
            gentimer.Enabled = True
        Else
            ' Loop until the stack is empty
            While genstack.Count > 0
                Dim currentCell = genstack.Peek()
                Dim cell = maze(currentCell.X, currentCell.Y)

                ' Mark the current cell as visited
                cell.visited = True

                ' Get the unvisited neighbors of the current cell
                Dim unvisitedNeighbours = cell.GetUnvisitedNeighbours(False)

                ' If all neighbors are visited, switch to hunt mode
                If unvisitedNeighbours.All(Function(p) p.Equals(Point.Empty)) = True Then
                    'find an unvisited neighbour next to visited cell
                    If huntMode = True Then
                        Dim huntTarget = FindHuntTarget(unvisitedNeighbours)
                        If huntTarget <> Nothing Then
                            genstack.Push(huntTarget)
                            huntMode = False ' Exit hunt mode
                            Continue While ' Continue DFS from the newly found cell
                        End If
                    End If
                    If unvisitedNeighbours.Count = 0 Then Exit While

                    'enter hunt mode 
                    huntMode = True
                    Continue While
                End If

                ' If in hunt mode, continue the loop
                If huntMode = True Then Continue While

                Dim valNeighbours = unvisitedNeighbours.Where(Function(p) p <> Point.Empty).ToList()

                ' Randomly choose a valid direction from the list of non-empty neighbors
                Randomize()
                direction = unvisitedNeighbours.IndexOf(valNeighbours(random.Next(0, valNeighbours.Count())))

                Dim neighbours = cell.removeWall(direction)
                genstack.Push(neighbours)
            End While
        End If

    End Sub

    ' Helper function to find an unvisited neighbor adjacent to a visited cell
    Private Function FindHuntTarget(unvisneigh As List(Of Point))

        If unvisneigh.Count > 0 Then
            ' Randomly select from the list of potential hunt targets
            Randomize()
            Dim index As Integer = random.Next(0, unvisneigh.Count)
            Dim target As Point = unvisneigh(index)
            unvisneigh.RemoveAt(index)
            Return target
        End If
        Return Nothing

    End Function

    Private Sub gentimer_tick(sender As Object, e As EventArgs) 'animation

        If cancelAnimation = True Then
            animationbtn.Checked = False
            gentimer.Enabled = False
            resetType = "G"
            reset()
            backloggprotect(False)
            cancelAnimation = False
            Exit Sub
        End If
        With MazeGraphics
            If generationAlgorithm = "DFS " Then
                If genstack.Count > 0 Then
                    Dim currentCell = genstack.Peek()
                    Dim cell = maze(currentCell.X, currentCell.Y)

                    ' Highlight the top of the stack
                    If currentCell <> mentry And currentCell <> mexit Then
                        .FillRectangle(New SolidBrush(Color.SteelBlue), currentCell.X * m, currentCell.Y * m, m, m)
                        maze(currentCell.X, currentCell.Y).drawWalls()
                    End If


                    ' Mark current cell as visited
                    cell.visited = True

                    ' Get a list of unvisited neighbors
                    Dim unvisitedNeighbors = cell.GetUnvisitedNeighbours(False)

                    If unvisitedNeighbors.All(Function(p) p.Equals(Point.Empty)) = True Then
                        genstack.Pop()
                    Else
                        ' Make a new list that only contains the non empty values from neighbour
                        Dim valNeigbours As New List(Of Point)
                        For Each point In unvisitedNeighbors
                            If point <> Point.Empty Then
                                valNeigbours.Add(point)
                            End If
                        Next

                        ' Randomly pick a valid neighbour. Find the index of that point within the orginal neighbour list and set that to direction
                        Dim direction = unvisitedNeighbors.IndexOf(valNeigbours(random.Next(0, valNeigbours.Count())))

                        ' Break the wall between the current cell and the chosen neighbor
                        Dim randomNeighbor = cell.removeWall(direction)

                        ' Add the neighbor to the stack
                        genstack.Push(randomNeighbor)
                    End If

                    ' Update the maze and the maze display
                    PictureBox1.Image = mazeimage
                    PictureBox1.Update()

                    ' Restart at the top of the stack
                    If currentCell <> mentry And currentCell <> mexit Then

                        .FillRectangle(New SolidBrush(Color.White), currentCell.X * m, currentCell.Y * m, m, m)

                        maze(currentCell.X, currentCell.Y).drawWalls()
                    End If
                Else
                    drawMaze()
                    ' Update the maze and the maze display
                    PictureBox1.Image = mazeimage
                    PictureBox1.Update()

                    backloggprotect(False)
                    ' Stop the timer when the maze is complete
                    gentimer.Enabled = False
                End If
            End If
        End With

    End Sub

    'solving
    Private Function astar()

        gweight.Clear()
        closedset.Clear()
        Dim openSet As New PriorityQueue(Of Double, Point)
        Dim parent As New Dictionary(Of Point, Point)
        gweight(mentry) = 0
        openSet.Enqueue(Manhattan(mentry, mexit), mentry)
        While Not openSet.isEmpty()

            Dim currentNode As Point = openSet.Dequeue()

            closedset.Enqueue(currentNode)

            If currentNode = mexit Then
                ' Reconstruct and return the path if the destination is reached
                Exit While
            End If



            For Each neighbour In maze(currentNode.X, currentNode.Y).concell 'GetNeighbours(currentNode) 'just going to add this fucker to see what happens. 
                If closedset.Contains(neighbour) Then
                    Continue For ' Skip already checked nodes
                End If

                H = gweight(currentNode) + Manhattan(currentNode, neighbour)
                If Not gweight.ContainsKey(neighbour) Then
                    gweight(neighbour) = Double.MaxValue
                End If
                ' Update the neighbours gWeight and parent if the heuristic weight is lower
                If H < gweight(neighbour) Then
                    parent(neighbour) = currentNode
                    gweight(neighbour) = H
                    maxweight = Math.Max(maxweight, H)
                    F = gweight(neighbour) + Manhattan(neighbour, mexit)


                    If Not openSet.Contains(neighbour) Then
                        openSet.Enqueue(F, neighbour)
                    End If
                End If

            Next


            reconstruct(parent, False)
            If animationbtn.Checked = False Then
                ' Marking the solution in the maze
                reconstruct(parent, True)
                path.Clear()

            ElseIf animationbtn.Checked = True Then
                backloggprotect(True)
                searchtimer.Enabled = True

            End If
        End While

    End Function

    Private Sub Dijkstra()

        gweight.Clear()
        closedset.Clear()
        Dim openSet As New PriorityQueue(Of Double, Point)
        Dim parent As New Dictionary(Of Point, Point)

        gweight(mentry) = 0
        openSet.Enqueue(0, mentry)

        While Not openSet.isEmpty()
            ' Find the node with the minimum cost in the open set
            Dim currentNode As Point = openSet.Dequeue()

            closedset.Enqueue(currentNode)

            If currentNode.Equals(mexit) Then ' Maze gets solved by the dumb ai
                Exit While
            End If

            For Each neighbour In maze(currentNode.X, currentNode.Y).concell ' Well, you were a member of form1.cell 30 seconds ago. 'GetNeighbours(currentNode) fucker doesnt work. walls innit
                ' Calculate weight of neighbour. In this case, getting to a connected node holds a weight of 1
                F = gweight(currentNode) + 1

                ' If the neighbour's weight is not already in the dictionary, set it to a large value
                If Not gweight.ContainsKey(neighbour) Then
                    gweight(neighbour) = Double.MaxValue
                End If

                ' Update the neighbour's weight and parent if the calculated weight is less
                If F < gweight(neighbour) Then
                    gweight(neighbour) = F
                    maxweight = Math.Max(maxweight, F)
                    parent(neighbour) = currentNode

                    ' If the neighbour is not in the priority queue, add it
                    If Not openSet.Contains(neighbour) Then
                        openSet.Enqueue(F, neighbour)
                    End If
                End If
            Next
        End While

        reconstruct(parent, False)
        If animationbtn.Checked = False Then
            ' Marking the solution in the maze
            reconstruct(parent, True)
            path.Clear()
        ElseIf animationbtn.Checked = True Then
            backloggprotect(True)
            searchtimer.Enabled = True

        End If

    End Sub

    Public Function reconstruct(parent As Dictionary(Of Point, Point), full As Boolean)

        If full = True Then
            For Each node In path
                maze(node.X, node.Y).msolv = True
            Next
            path.Clear()
        ElseIf full = False Then
            Dim current As Point = mexit
            While current <> mentry AndAlso parent.ContainsKey(current)
                current = parent(current)
                If current <> mentry Then
                    path.Enqueue(current)
                End If
            End While
        End If

    End Function

    Private Function Manhattan(point1 As Point, point2 As Point) As Double
        Return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y)
    End Function

    Function coloursarecool(colour1 As Color, colour2 As Color, ratio As Double) As Color
        Dim r As Double = Int(colour1.R) + (Int(colour2.R) - Int(colour1.R)) * ratio
        Dim g As Double = Int(colour1.G) + (Int(colour2.G) - Int(colour1.G)) * ratio
        Dim b As Double = Int(colour1.B) + (Int(colour2.B) - Int(colour1.B)) * ratio
        Return Color.FromArgb((r), (g), (b))
    End Function

    Private Sub searchanimation_tick(sender As Object, e As EventArgs)

        If cancelAnimation = True Then
            animationbtn.Checked = False
            searchtimer.Enabled = False
            solvedpathtimer.Enabled = False
            resetType = "S"
            reset()
            backloggprotect(False)
            cancelAnimation = False
            Exit Sub
        End If
        If closedset.Count > 0 Then
            Dim Pnt As Point = closedset.Dequeue
            If Pnt <> mentry And Pnt <> mexit Then
                Dim realweight As Double = gweight(Pnt) / maxweight
                MazeGraphics.FillRectangle(New SolidBrush(coloursarecool(azure, steel, realweight)), Pnt.X * m, Pnt.Y * m, m, m)
                maze(Pnt.X, Pnt.Y).drawWalls()
                PictureBox1.Image = mazeimage
                PictureBox1.Update()
            End If
        Else
            closedset.Clear()
            drawMaze()
            searchtimer.Enabled = False
            solvedpathtimer.Enabled = True
        End If

    End Sub

    Private Sub solvpath_tick(sender As Object, e As EventArgs)

        If cancelAnimation = True Then
            animationbtn.Checked = False
            searchtimer.Enabled = False
            solvedpathtimer.Enabled = False
            resetType = "S"
            reset()
            backloggprotect(False)
            cancelAnimation = False
            Exit Sub
        End If
        With MazeGraphics
            If path.Count > 0 Then
                Dim current As Point = path.Dequeue
                If passedPath.Count > 0 Then
                    Dim previous As Point = passedPath.Last()
                    .FillRectangle(New SolidBrush(Color.RebeccaPurple), previous.X * m, previous.Y * m, m, m)
                    maze(previous.X, previous.Y).drawWalls()
                End If
                'currentcell colour
                .FillRectangle(New SolidBrush(Color.SteelBlue), current.X * m, current.Y * m, m, m)

                maze(current.X, current.Y).drawWalls()
                passedPath.Add(current)

                maze(current.X, current.Y).msolv = True

                PictureBox1.Image = mazeimage
                PictureBox1.Update()
            Else
                If passedPath.Count > 0 Then
                    Dim last As Point = passedPath.Last()
                    .FillRectangle(New SolidBrush(Color.RebeccaPurple), last.X * m, last.Y * m, m, m)
                    maze(last.X, last.Y).drawWalls()

                    ' Updates maze box
                    PictureBox1.Image = mazeimage
                    PictureBox1.Update()
                End If
                solvedpathtimer.Enabled = False
                backloggprotect(False)
                path.Clear()
                passedPath.Clear()
            End If
        End With

    End Sub

    Private Sub mapmode()

        Dim maptoremove, direction As Integer
        Dim mapend, node As Point
        For Each cell In maze
            cell.mapwallpos()
        Next
        maptoremove = Math.Round(deadEnd.Count() * mapmodepercent)
        Dim mapremove As Integer = 0
        While mapremove <> maptoremove
            mapend = deadEnd(random.Next(0, deadEnd.Count))
            Dim validmap As New List(Of Integer)
            For i As Integer = 0 To 3
                If maze(mapend.X, mapend.Y).walls(i) Then
                    validmap.Add(i)
                End If
            Next
            Do
                direction = validmap(random.Next(0, validmap.Count))
                node = maze(mapend.X, mapend.Y).removeWall(direction)
            Loop While node.IsEmpty
            deadEnd.Remove(mapend)
            If deadEnd.Contains(node) Then
                deadEnd.Remove(node)
                mapremove += 1
            End If
            mapremove += 1
        End While
        deadEnd.Clear()
        backloggprotect(False)

    End Sub

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
        entryexit = entryexitcombo.Text
        generationAlgorithm = generationCombo.Text
        If Math.Floor(Math.Min(1222 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text))) < 3 Then
            MsgBox("WIDTH >407 AND/OR HEIGHT >230" & vbCrLf & "Do you wish to download maze?", MsgBoxStyle.OkCancel, "ERROR:")

        Else

            m = Math.Floor(Math.Min(1222 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text)))
        End If

        ' Initializes the maze
        InitializeMaze()
        ' Allows the program to know whether or not a maze has been generated
        mazegen = True

        ' Resets old timer, Starts new timer, Updates Status
        UpdateStatusLabel("Generating")

        generationtimer.Reset()
        generationtimer.Start()
        ' Checks what generation algorithm the user has chosen
        If generationAlgorithm = "DFS " Then

            DFS(random.Next(1, width), random.Next(1, height))

        End If
        If generationAlgorithm = "Hunt And Kill" Then

            HK(random.Next(1, width), random.Next(1, height))

        End If
        generationtimer.Stop()
        ' Draws the generated maze
        drawMaze()
        PictureBox1.Image = mazeimage 'updating the output image to be unsolved maze
        gentimelbl.Text = "Generation Time: " & Str(generationtimer.ElapsedMilliseconds() / 1000) & "s"
        drawlbl.Text = "Draw Time: " & Str(drawTimer.ElapsedMilliseconds() / 1000) & "s"
        sollbl.Text = "Solve Time "
        UpdateStatusLabel("Doing Nothing")
    End Sub

    Private Sub solBtn_Click(sender As Object, e As EventArgs) Handles SolBtn.Click

        ' Makes sure a maze has been generated 
        If mazegen = False Then
            MsgBox("No maze generated!" & vbCrLf & "Please press the generate button", MsgBoxStyle.OkOnly, "No maze generated")
            Exit Sub
        End If
        ' Sets solving algorithim to what the user has selected
        solvealgorithm = solveCombo.Text

        ' Reset all cells that have .mSolv = True
        For Each cell In maze
            cell.msolv = False
        Next

        ' Checks if the maze can be displayed (again)
        If Math.Floor(Math.Min(1222 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text))) < 3 Then
            MsgBox("Maze is too big to display!")
        End If

        ' Resets old timer, Starts new timer, Upates Status

        UpdateStatusLabel("Solving")
        solveTimer.Reset()
        solveTimer.Start()

        ' Checks what solving algorithm user has chosen
        If solvealgorithm = "Dijkstra's" Then
            Dijkstra()

        ElseIf solvealgorithm = "A*" Then
            astar()
        End If
        solveTimer.Stop()
        ' Upadtes Maze box
        drawMaze()
        PictureBox1.Image = mazeimage 'bane of my existance. took too long to actually realise this was missing and hence my maze was not drawing...
        ' Resets Status
        sollbl.Text = "Solve Time: " & Str(solveTimer.ElapsedMilliseconds() / 1000) & "s"
        UpdateStatusLabel("Solution Drawn")

    End Sub
    Private Sub mapmodebtn_click(sender As Object, e As EventArgs) Handles mapmodebtn.Click

        If mazegen = False Then
            MsgBox("No maze generated!" & vbCrLf & "Please press the generate button", MsgBoxStyle.OkOnly, "No maze generated")
            Exit Sub
        End If
        Dim randoms As New Random()
        mapmodepercent = Math.Round(CDec(randoms.NextDouble() * 0.99 + 0.01), 2)
        mapmode()
        For Each cell In maze
            cell.msolv = False
        Next
        drawMaze()
        PictureBox1.Image = mazeimage
        For Each cell In maze
            cell.mapwallpos()
        Next

    End Sub
    Private Sub UpdateStatusLabel(ByVal status As String)
        statusLbl.Text = "Status: " & status
        statusLbl.Update()
    End Sub

    Private Sub savemaze()

        If mazegen = True Then
            Dim openfile As New SaveFileDialog
            openfile.FileName = Nothing
            openfile.Filter = "JPG File|*.jpg"
            openfile.ShowDialog()
            mazeimage.Save(openfile.FileName)
        End If

    End Sub

    Private Sub mSaveBtn_click(sender As Object, e As EventArgs)
        savemaze()
    End Sub

    Private Sub cnclanimation_click(sender As Object, e As EventArgs)
        cancelAnimation = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        MsgBox("Enter Width and Height Parameters in the spaces below, " & vbCrLf & "You can opt to select animations of the maze before generating the algorithm" & vbCrLf & "")
    End Sub
End Class
