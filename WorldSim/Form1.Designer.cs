﻿namespace WorldSim
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.button_Reset = new System.Windows.Forms.Button();
      this.button_Sim1 = new System.Windows.Forms.Button();
      this.button_StepMult = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.panel_Map = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.label_Steps = new System.Windows.Forms.Label();
      this.label_Alive = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button_Reset
      // 
      this.button_Reset.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Reset.Location = new System.Drawing.Point(26, 13);
      this.button_Reset.Name = "button_Reset";
      this.button_Reset.Size = new System.Drawing.Size(115, 28);
      this.button_Reset.TabIndex = 0;
      this.button_Reset.Text = "RESET";
      this.button_Reset.UseVisualStyleBackColor = true;
      this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
      // 
      // button_Sim1
      // 
      this.button_Sim1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Sim1.Location = new System.Drawing.Point(147, 12);
      this.button_Sim1.Name = "button_Sim1";
      this.button_Sim1.Size = new System.Drawing.Size(115, 28);
      this.button_Sim1.TabIndex = 1;
      this.button_Sim1.Text = "SIM 1 STEP";
      this.button_Sim1.UseVisualStyleBackColor = true;
      this.button_Sim1.Click += new System.EventHandler(this.button_Sim1_Click);
      // 
      // button_StepMult
      // 
      this.button_StepMult.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_StepMult.Location = new System.Drawing.Point(268, 13);
      this.button_StepMult.Name = "button_StepMult";
      this.button_StepMult.Size = new System.Drawing.Size(115, 28);
      this.button_StepMult.TabIndex = 2;
      this.button_StepMult.Text = "SIM STEP *";
      this.button_StepMult.UseVisualStyleBackColor = true;
      this.button_StepMult.Click += new System.EventHandler(this.button_StepMult_Click);
      // 
      // textBox1
      // 
      this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(389, 14);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(115, 26);
      this.textBox1.TabIndex = 3;
      this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
      // 
      // panel_Map
      // 
      this.panel_Map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel_Map.AutoSize = true;
      this.panel_Map.Location = new System.Drawing.Point(12, 99);
      this.panel_Map.Name = "panel_Map";
      this.panel_Map.Size = new System.Drawing.Size(510, 400);
      this.panel_Map.TabIndex = 4;
      this.panel_Map.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Map_Paint);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 44);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(63, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "STEP NR - ";
      // 
      // label_Steps
      // 
      this.label_Steps.AutoSize = true;
      this.label_Steps.Location = new System.Drawing.Point(111, 44);
      this.label_Steps.Name = "label_Steps";
      this.label_Steps.Size = new System.Drawing.Size(13, 13);
      this.label_Steps.TabIndex = 6;
      this.label_Steps.Text = "0";
      // 
      // label_Alive
      // 
      this.label_Alive.AutoSize = true;
      this.label_Alive.Location = new System.Drawing.Point(111, 57);
      this.label_Alive.Name = "label_Alive";
      this.label_Alive.Size = new System.Drawing.Size(13, 13);
      this.label_Alive.TabIndex = 8;
      this.label_Alive.Text = "0";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(23, 57);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(88, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "BEASTS ALIVE -";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(534, 511);
      this.Controls.Add(this.label_Alive);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label_Steps);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel_Map);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button_StepMult);
      this.Controls.Add(this.button_Sim1);
      this.Controls.Add(this.button_Reset);
      this.Name = "Form1";
      this.Text = "WorldSim";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_Reset;
    private System.Windows.Forms.Button button_Sim1;
    private System.Windows.Forms.Button button_StepMult;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Panel panel_Map;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label_Steps;
    private System.Windows.Forms.Label label_Alive;
    private System.Windows.Forms.Label label3;
  }
}

