<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        statusLbl = New Label()
        PictureBox1 = New PictureBox()
        heightTxtBox = New TextBox()
        widthTxtBox = New TextBox()
        generationCombo = New ComboBox()
        solveCombo = New ComboBox()
        Label9 = New Label()
        mColBtn = New Button()
        sColBtn = New Button()
        Label10 = New Label()
        GenBtn = New Button()
        SolBtn = New Button()
        mSaveBtn = New Button()
        PictureBox2 = New PictureBox()
        gentimelbl = New Label()
        sollbl = New Label()
        drawlbl = New Label()
        gentimer = New Timer(components)
        solvedpathtimer = New Timer(components)
        searchtimer = New Timer(components)
        animationbtn = New CheckBox()
        entryexitcombo = New ComboBox()
        cnclanimation = New Button()
        mapmodebtn = New Button()
        PictureBox3 = New PictureBox()
        Label6 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(19, 255)
        Label1.Name = "Label1"
        Label1.Size = New Size(207, 40)
        Label1.TabIndex = 0
        Label1.Text = "Maze Width"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(17, 377)
        Label2.Name = "Label2"
        Label2.Size = New Size(259, 40)
        Label2.TabIndex = 1
        Label2.Text = "Entry/Exit point"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(19, 321)
        Label3.Name = "Label3"
        Label3.Size = New Size(219, 40)
        Label3.TabIndex = 2
        Label3.Text = "Maze Height"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(12, 439)
        Label4.Name = "Label4"
        Label4.Size = New Size(357, 40)
        Label4.TabIndex = 3
        Label4.Text = "Generation Algorithm"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(17, 508)
        Label5.Name = "Label5"
        Label5.Size = New Size(297, 40)
        Label5.TabIndex = 4
        Label5.Text = "Solving Algorithm"
        ' 
        ' statusLbl
        ' 
        statusLbl.AutoSize = True
        statusLbl.Font = New Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        statusLbl.ForeColor = Color.Black
        statusLbl.Location = New Point(1546, 51)
        statusLbl.Name = "statusLbl"
        statusLbl.Size = New Size(101, 37)
        statusLbl.TabIndex = 6
        statusLbl.Text = "Status: "
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Location = New Point(672, 152)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1220, 691)
        PictureBox1.TabIndex = 11
        PictureBox1.TabStop = False
        ' 
        ' heightTxtBox
        ' 
        heightTxtBox.BackColor = Color.White
        heightTxtBox.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point)
        heightTxtBox.ForeColor = Color.Black
        heightTxtBox.Location = New Point(393, 308)
        heightTxtBox.Margin = New Padding(3, 2, 3, 2)
        heightTxtBox.MaxLength = 4
        heightTxtBox.Multiline = True
        heightTxtBox.Name = "heightTxtBox"
        heightTxtBox.Size = New Size(273, 53)
        heightTxtBox.TabIndex = 14
        heightTxtBox.Text = "6"
        heightTxtBox.TextAlign = HorizontalAlignment.Center
        ' 
        ' widthTxtBox
        ' 
        widthTxtBox.BackColor = Color.White
        widthTxtBox.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point)
        widthTxtBox.ForeColor = Color.Black
        widthTxtBox.Location = New Point(393, 242)
        widthTxtBox.Margin = New Padding(3, 2, 3, 2)
        widthTxtBox.MaxLength = 4
        widthTxtBox.Multiline = True
        widthTxtBox.Name = "widthTxtBox"
        widthTxtBox.Size = New Size(273, 53)
        widthTxtBox.TabIndex = 19
        widthTxtBox.Text = "6"
        widthTxtBox.TextAlign = HorizontalAlignment.Center
        ' 
        ' generationCombo
        ' 
        generationCombo.BackColor = Color.White
        generationCombo.Cursor = Cursors.Hand
        generationCombo.FlatStyle = FlatStyle.Flat
        generationCombo.Font = New Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point)
        generationCombo.ForeColor = Color.Black
        generationCombo.FormattingEnabled = True
        generationCombo.Items.AddRange(New Object() {"DFS ", "Hunt And Kill"})
        generationCombo.Location = New Point(393, 434)
        generationCombo.Margin = New Padding(3, 2, 3, 2)
        generationCombo.Name = "generationCombo"
        generationCombo.Size = New Size(273, 45)
        generationCombo.TabIndex = 28
        generationCombo.Text = "Select Algorithm:"
        ' 
        ' solveCombo
        ' 
        solveCombo.BackColor = Color.White
        solveCombo.Cursor = Cursors.Hand
        solveCombo.FlatStyle = FlatStyle.Flat
        solveCombo.Font = New Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point)
        solveCombo.ForeColor = Color.Black
        solveCombo.FormattingEnabled = True
        solveCombo.Items.AddRange(New Object() {"Dijkstra's", "A*"})
        solveCombo.Location = New Point(393, 503)
        solveCombo.Margin = New Padding(3, 2, 3, 2)
        solveCombo.Name = "solveCombo"
        solveCombo.Size = New Size(273, 45)
        solveCombo.TabIndex = 29
        solveCombo.Text = "Select Algorithm:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = SystemColors.ActiveCaption
        Label9.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.ForeColor = Color.Black
        Label9.ImeMode = ImeMode.NoControl
        Label9.Location = New Point(17, 591)
        Label9.Name = "Label9"
        Label9.Size = New Size(221, 40)
        Label9.TabIndex = 30
        Label9.Text = "Maze Colour"
        ' 
        ' mColBtn
        ' 
        mColBtn.Font = New Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point)
        mColBtn.Location = New Point(393, 580)
        mColBtn.Name = "mColBtn"
        mColBtn.Size = New Size(273, 67)
        mColBtn.TabIndex = 31
        mColBtn.Text = "Select Colour"
        mColBtn.UseVisualStyleBackColor = True
        ' 
        ' sColBtn
        ' 
        sColBtn.Font = New Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point)
        sColBtn.Location = New Point(393, 667)
        sColBtn.Name = "sColBtn"
        sColBtn.Size = New Size(273, 67)
        sColBtn.TabIndex = 32
        sColBtn.Text = "Select Colour"
        sColBtn.UseVisualStyleBackColor = True
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = SystemColors.ActiveCaption
        Label10.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.Black
        Label10.ImeMode = ImeMode.NoControl
        Label10.Location = New Point(17, 694)
        Label10.Name = "Label10"
        Label10.Size = New Size(223, 40)
        Label10.TabIndex = 33
        Label10.Text = "Solve Colour"
        ' 
        ' GenBtn
        ' 
        GenBtn.BackColor = Color.MidnightBlue
        GenBtn.Font = New Font("Microsoft Sans Serif", 17F, FontStyle.Regular, GraphicsUnit.Point)
        GenBtn.ForeColor = Color.White
        GenBtn.Location = New Point(672, 871)
        GenBtn.Name = "GenBtn"
        GenBtn.Size = New Size(400, 73)
        GenBtn.TabIndex = 34
        GenBtn.Text = "Generate Maze "
        GenBtn.UseVisualStyleBackColor = False
        ' 
        ' SolBtn
        ' 
        SolBtn.BackColor = Color.DarkGreen
        SolBtn.Font = New Font("Microsoft Sans Serif", 17F, FontStyle.Regular, GraphicsUnit.Point)
        SolBtn.ForeColor = Color.White
        SolBtn.Location = New Point(1082, 871)
        SolBtn.Name = "SolBtn"
        SolBtn.Size = New Size(400, 73)
        SolBtn.TabIndex = 35
        SolBtn.Text = "Solve Maze"
        SolBtn.UseVisualStyleBackColor = False
        ' 
        ' mSaveBtn
        ' 
        mSaveBtn.BackColor = Color.DarkMagenta
        mSaveBtn.Font = New Font("Microsoft Sans Serif", 17F, FontStyle.Regular, GraphicsUnit.Point)
        mSaveBtn.ForeColor = Color.White
        mSaveBtn.Location = New Point(1492, 871)
        mSaveBtn.Name = "mSaveBtn"
        mSaveBtn.Size = New Size(400, 73)
        mSaveBtn.TabIndex = 36
        mSaveBtn.Text = "Save Solved Maze"
        mSaveBtn.UseVisualStyleBackColor = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = SystemColors.GradientActiveCaption
        PictureBox2.Location = New Point(17, 763)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(629, 275)
        PictureBox2.TabIndex = 37
        PictureBox2.TabStop = False
        ' 
        ' gentimelbl
        ' 
        gentimelbl.AutoSize = True
        gentimelbl.BackColor = SystemColors.GradientActiveCaption
        gentimelbl.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        gentimelbl.Location = New Point(53, 802)
        gentimelbl.Name = "gentimelbl"
        gentimelbl.Size = New Size(171, 25)
        gentimelbl.TabIndex = 38
        gentimelbl.Text = "Generation Time"
        ' 
        ' sollbl
        ' 
        sollbl.AutoSize = True
        sollbl.BackColor = SystemColors.GradientActiveCaption
        sollbl.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        sollbl.Location = New Point(53, 928)
        sollbl.Name = "sollbl"
        sollbl.Size = New Size(119, 25)
        sollbl.TabIndex = 39
        sollbl.Text = "Solve Time"
        ' 
        ' drawlbl
        ' 
        drawlbl.AutoSize = True
        drawlbl.BackColor = SystemColors.GradientActiveCaption
        drawlbl.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        drawlbl.Location = New Point(53, 858)
        drawlbl.Name = "drawlbl"
        drawlbl.Size = New Size(120, 25)
        drawlbl.TabIndex = 40
        drawlbl.Text = "Draw Time "
        ' 
        ' animationbtn
        ' 
        animationbtn.AutoSize = True
        animationbtn.BackColor = Color.Transparent
        animationbtn.CheckAlign = ContentAlignment.MiddleRight
        animationbtn.Font = New Font("Segoe UI", 29.25F, FontStyle.Regular, GraphicsUnit.Point)
        animationbtn.ForeColor = Color.Black
        animationbtn.ImeMode = ImeMode.NoControl
        animationbtn.Location = New Point(12, 187)
        animationbtn.Name = "animationbtn"
        animationbtn.Size = New Size(235, 56)
        animationbtn.TabIndex = 41
        animationbtn.Text = "Animations"
        animationbtn.TextAlign = ContentAlignment.MiddleCenter
        animationbtn.UseVisualStyleBackColor = False
        ' 
        ' entryexitcombo
        ' 
        entryexitcombo.BackColor = Color.White
        entryexitcombo.Cursor = Cursors.Hand
        entryexitcombo.FlatStyle = FlatStyle.Flat
        entryexitcombo.Font = New Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point)
        entryexitcombo.ForeColor = Color.Black
        entryexitcombo.FormattingEnabled = True
        entryexitcombo.Items.AddRange(New Object() {"Random", "Labyrinth", "Labyrinth 2", "Top/Bottom", "Left/Right"})
        entryexitcombo.Location = New Point(393, 372)
        entryexitcombo.Margin = New Padding(3, 2, 3, 2)
        entryexitcombo.Name = "entryexitcombo"
        entryexitcombo.Size = New Size(273, 45)
        entryexitcombo.TabIndex = 27
        entryexitcombo.Text = "Set Entry/Exit:"
        ' 
        ' cnclanimation
        ' 
        cnclanimation.BackColor = Color.Crimson
        cnclanimation.Font = New Font("Microsoft Sans Serif", 17F, FontStyle.Regular, GraphicsUnit.Point)
        cnclanimation.ForeColor = Color.White
        cnclanimation.Location = New Point(1082, 965)
        cnclanimation.Name = "cnclanimation"
        cnclanimation.Size = New Size(400, 73)
        cnclanimation.TabIndex = 42
        cnclanimation.Text = "Cancel Animation "
        cnclanimation.UseVisualStyleBackColor = False
        ' 
        ' mapmodebtn
        ' 
        mapmodebtn.BackColor = Color.SeaGreen
        mapmodebtn.Font = New Font("Microsoft Sans Serif", 17F, FontStyle.Regular, GraphicsUnit.Point)
        mapmodebtn.ForeColor = Color.White
        mapmodebtn.Location = New Point(672, 965)
        mapmodebtn.Name = "mapmodebtn"
        mapmodebtn.Size = New Size(400, 73)
        mapmodebtn.TabIndex = 43
        mapmodebtn.Text = "Map Mode"
        mapmodebtn.UseVisualStyleBackColor = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.White
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(17, 27)
        PictureBox3.Margin = New Padding(3, 2, 3, 2)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(189, 155)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 44
        PictureBox3.TabStop = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(212, 27)
        Label6.Name = "Label6"
        Label6.Size = New Size(463, 40)
        Label6.TabIndex = 45
        Label6.Text = "<- Click for Help Information"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1904, 1161)
        Controls.Add(Label6)
        Controls.Add(PictureBox3)
        Controls.Add(mapmodebtn)
        Controls.Add(cnclanimation)
        Controls.Add(entryexitcombo)
        Controls.Add(animationbtn)
        Controls.Add(drawlbl)
        Controls.Add(sollbl)
        Controls.Add(gentimelbl)
        Controls.Add(PictureBox2)
        Controls.Add(mSaveBtn)
        Controls.Add(SolBtn)
        Controls.Add(GenBtn)
        Controls.Add(Label10)
        Controls.Add(sColBtn)
        Controls.Add(mColBtn)
        Controls.Add(Label9)
        Controls.Add(solveCombo)
        Controls.Add(generationCombo)
        Controls.Add(widthTxtBox)
        Controls.Add(heightTxtBox)
        Controls.Add(PictureBox1)
        Controls.Add(statusLbl)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Worthy of 100%"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents statusLbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents heightTxtBox As TextBox
    Friend WithEvents widthTxtBox As TextBox
    Friend WithEvents generationCombo As ComboBox
    Friend WithEvents solveCombo As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents mColBtn As Button
    Friend WithEvents sColBtn As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents GenBtn As Button
    Friend WithEvents SolBtn As Button
    Friend WithEvents mSaveBtn As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents gentimelbl As Label
    Friend WithEvents sollbl As Label
    Friend WithEvents drawlbl As Label
    Friend WithEvents gentimer As Timer
    Friend WithEvents solvedpathtimer As Timer
    Friend WithEvents searchtimer As Timer
    Friend WithEvents animationbtn As CheckBox
    Friend WithEvents entryexitcombo As ComboBox
    Friend WithEvents cnclanimation As Button
    Friend WithEvents mapmodebtn As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label6 As Label
End Class
