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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.statusLbl = New System.Windows.Forms.Label()
        Me.depthTxtBox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.heightTxtBox = New System.Windows.Forms.TextBox()
        Me.widthTxtBox = New System.Windows.Forms.TextBox()
        Me.generationCombo = New System.Windows.Forms.ComboBox()
        Me.solveCombo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mColBtn = New System.Windows.Forms.Button()
        Me.sColBtn = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GenBtn = New System.Windows.Forms.Button()
        Me.SolBtn = New System.Windows.Forms.Button()
        Me.mSaveBtn = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.gentimelbl = New System.Windows.Forms.Label()
        Me.sollbl = New System.Windows.Forms.Label()
        Me.drawlbl = New System.Windows.Forms.Label()
        Me.gentimer = New System.Windows.Forms.Timer(Me.components)
        Me.solvedpathtimer = New System.Windows.Forms.Timer(Me.components)
        Me.searchtimer = New System.Windows.Forms.Timer(Me.components)
        Me.animationbtn = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Maze Width"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(17, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Maze Depth"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(17, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 40)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Maze Height"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(17, 374)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(357, 40)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Generation Algorithm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(17, 444)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(297, 40)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Solving Algorithm"
        '
        'statusLbl
        '
        Me.statusLbl.AutoSize = True
        Me.statusLbl.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.statusLbl.ForeColor = System.Drawing.Color.Black
        Me.statusLbl.Location = New System.Drawing.Point(1546, 51)
        Me.statusLbl.Name = "statusLbl"
        Me.statusLbl.Size = New System.Drawing.Size(101, 37)
        Me.statusLbl.TabIndex = 6
        Me.statusLbl.Text = "Status: "
        '
        'depthTxtBox
        '
        Me.depthTxtBox.Location = New System.Drawing.Point(389, 235)
        Me.depthTxtBox.Name = "depthTxtBox"
        Me.depthTxtBox.Size = New System.Drawing.Size(273, 23)
        Me.depthTxtBox.TabIndex = 8
        Me.depthTxtBox.Text = "Under Construction"
        Me.depthTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(672, 152)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1220, 691)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'heightTxtBox
        '
        Me.heightTxtBox.BackColor = System.Drawing.Color.White
        Me.heightTxtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.heightTxtBox.ForeColor = System.Drawing.Color.Black
        Me.heightTxtBox.Location = New System.Drawing.Point(389, 305)
        Me.heightTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.heightTxtBox.MaxLength = 4
        Me.heightTxtBox.Multiline = True
        Me.heightTxtBox.Name = "heightTxtBox"
        Me.heightTxtBox.Size = New System.Drawing.Size(273, 53)
        Me.heightTxtBox.TabIndex = 14
        Me.heightTxtBox.Text = "6"
        Me.heightTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'widthTxtBox
        '
        Me.widthTxtBox.BackColor = System.Drawing.Color.White
        Me.widthTxtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.widthTxtBox.ForeColor = System.Drawing.Color.Black
        Me.widthTxtBox.Location = New System.Drawing.Point(389, 165)
        Me.widthTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.widthTxtBox.MaxLength = 4
        Me.widthTxtBox.Multiline = True
        Me.widthTxtBox.Name = "widthTxtBox"
        Me.widthTxtBox.Size = New System.Drawing.Size(273, 53)
        Me.widthTxtBox.TabIndex = 19
        Me.widthTxtBox.Text = "6"
        Me.widthTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'generationCombo
        '
        Me.generationCombo.BackColor = System.Drawing.Color.White
        Me.generationCombo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.generationCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.generationCombo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.generationCombo.ForeColor = System.Drawing.Color.Black
        Me.generationCombo.FormattingEnabled = True
        Me.generationCombo.Items.AddRange(New Object() {"DFS ", "Hunt And Kill"})
        Me.generationCombo.Location = New System.Drawing.Point(389, 374)
        Me.generationCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.generationCombo.Name = "generationCombo"
        Me.generationCombo.Size = New System.Drawing.Size(273, 45)
        Me.generationCombo.TabIndex = 28
        Me.generationCombo.Text = "Select Algorithm:"
        '
        'solveCombo
        '
        Me.solveCombo.BackColor = System.Drawing.Color.White
        Me.solveCombo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.solveCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.solveCombo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.solveCombo.ForeColor = System.Drawing.Color.Black
        Me.solveCombo.FormattingEnabled = True
        Me.solveCombo.Items.AddRange(New Object() {"Dijkstra's", "A*"})
        Me.solveCombo.Location = New System.Drawing.Point(389, 444)
        Me.solveCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.solveCombo.Name = "solveCombo"
        Me.solveCombo.Size = New System.Drawing.Size(273, 45)
        Me.solveCombo.TabIndex = 29
        Me.solveCombo.Text = "Select Algorithm:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(17, 515)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(221, 40)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Maze Colour"
        '
        'mColBtn
        '
        Me.mColBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.mColBtn.Location = New System.Drawing.Point(389, 502)
        Me.mColBtn.Name = "mColBtn"
        Me.mColBtn.Size = New System.Drawing.Size(273, 67)
        Me.mColBtn.TabIndex = 31
        Me.mColBtn.Text = "Select Colour"
        Me.mColBtn.UseVisualStyleBackColor = True
        '
        'sColBtn
        '
        Me.sColBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.sColBtn.Location = New System.Drawing.Point(389, 572)
        Me.sColBtn.Name = "sColBtn"
        Me.sColBtn.Size = New System.Drawing.Size(273, 67)
        Me.sColBtn.TabIndex = 32
        Me.sColBtn.Text = "Select Colour"
        Me.sColBtn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(17, 584)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(223, 40)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Solve Colour"
        '
        'GenBtn
        '
        Me.GenBtn.BackColor = System.Drawing.Color.MidnightBlue
        Me.GenBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GenBtn.ForeColor = System.Drawing.Color.White
        Me.GenBtn.Location = New System.Drawing.Point(672, 871)
        Me.GenBtn.Name = "GenBtn"
        Me.GenBtn.Size = New System.Drawing.Size(400, 73)
        Me.GenBtn.TabIndex = 34
        Me.GenBtn.Text = "Generate Maze "
        Me.GenBtn.UseVisualStyleBackColor = False
        '
        'SolBtn
        '
        Me.SolBtn.BackColor = System.Drawing.Color.DarkGreen
        Me.SolBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SolBtn.ForeColor = System.Drawing.Color.White
        Me.SolBtn.Location = New System.Drawing.Point(1082, 871)
        Me.SolBtn.Name = "SolBtn"
        Me.SolBtn.Size = New System.Drawing.Size(400, 73)
        Me.SolBtn.TabIndex = 35
        Me.SolBtn.Text = "Solve Maze"
        Me.SolBtn.UseVisualStyleBackColor = False
        '
        'mSaveBtn
        '
        Me.mSaveBtn.BackColor = System.Drawing.Color.DarkMagenta
        Me.mSaveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.mSaveBtn.ForeColor = System.Drawing.Color.White
        Me.mSaveBtn.Location = New System.Drawing.Point(1492, 871)
        Me.mSaveBtn.Name = "mSaveBtn"
        Me.mSaveBtn.Size = New System.Drawing.Size(400, 73)
        Me.mSaveBtn.TabIndex = 36
        Me.mSaveBtn.Text = "Save Solved Maze"
        Me.mSaveBtn.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox2.Location = New System.Drawing.Point(12, 669)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(629, 275)
        Me.PictureBox2.TabIndex = 37
        Me.PictureBox2.TabStop = False
        '
        'gentimelbl
        '
        Me.gentimelbl.AutoSize = True
        Me.gentimelbl.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.gentimelbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.gentimelbl.Location = New System.Drawing.Point(61, 726)
        Me.gentimelbl.Name = "gentimelbl"
        Me.gentimelbl.Size = New System.Drawing.Size(171, 25)
        Me.gentimelbl.TabIndex = 38
        Me.gentimelbl.Text = "Generation Time"
        '
        'sollbl
        '
        Me.sollbl.AutoSize = True
        Me.sollbl.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.sollbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.sollbl.Location = New System.Drawing.Point(61, 846)
        Me.sollbl.Name = "sollbl"
        Me.sollbl.Size = New System.Drawing.Size(119, 25)
        Me.sollbl.TabIndex = 39
        Me.sollbl.Text = "Solve Time"
        '
        'drawlbl
        '
        Me.drawlbl.AutoSize = True
        Me.drawlbl.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.drawlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.drawlbl.Location = New System.Drawing.Point(61, 786)
        Me.drawlbl.Name = "drawlbl"
        Me.drawlbl.Size = New System.Drawing.Size(120, 25)
        Me.drawlbl.TabIndex = 40
        Me.drawlbl.Text = "Draw Time "
        '
        'animationbtn
        '
        Me.animationbtn.AutoSize = True
        Me.animationbtn.BackColor = System.Drawing.Color.Transparent
        Me.animationbtn.Font = New System.Drawing.Font("Segoe UI", 29.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.animationbtn.ForeColor = System.Drawing.Color.White
        Me.animationbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.animationbtn.Location = New System.Drawing.Point(28, 62)
        Me.animationbtn.Name = "animationbtn"
        Me.animationbtn.Size = New System.Drawing.Size(235, 56)
        Me.animationbtn.TabIndex = 41
        Me.animationbtn.Text = "Animations"
        Me.animationbtn.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1904, 1161)
        Me.Controls.Add(Me.animationbtn)
        Me.Controls.Add(Me.drawlbl)
        Me.Controls.Add(Me.sollbl)
        Me.Controls.Add(Me.gentimelbl)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.mSaveBtn)
        Me.Controls.Add(Me.SolBtn)
        Me.Controls.Add(Me.GenBtn)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.sColBtn)
        Me.Controls.Add(Me.mColBtn)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.solveCombo)
        Me.Controls.Add(Me.generationCombo)
        Me.Controls.Add(Me.widthTxtBox)
        Me.Controls.Add(Me.heightTxtBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.depthTxtBox)
        Me.Controls.Add(Me.statusLbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Worthy of 100%"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents statusLbl As Label
    Friend WithEvents depthTxtBox As TextBox
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
End Class
