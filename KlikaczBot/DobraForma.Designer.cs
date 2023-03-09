namespace KlikaczBot;

partial class DobraForma
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
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.tabCalibration = new System.Windows.Forms.TabPage();
            this._btnCalibrateSendRun = new System.Windows.Forms.Button();
            this._labCalibrationButtons = new System.Windows.Forms.Label();
            this._btnCalibrateAceptEnedRun = new System.Windows.Forms.Button();
            this._btnCalibrateChangeTime = new System.Windows.Forms.Button();
            this._btnCalibrateFiveMinuteRunBtn = new System.Windows.Forms.Button();
            this._btnCalibrateFifteenMinuteRunBtn = new System.Windows.Forms.Button();
            this._btnCalibrateSixtyMinuteRunBtn = new System.Windows.Forms.Button();
            this._btnCalibrateTabWombatInBrowser = new System.Windows.Forms.Button();
            this._btnCalibrateNextTabInBrowser = new System.Windows.Forms.Button();
            this._btnCalibrateMaxBrowserWindow = new System.Windows.Forms.Button();
            this._btnCalibrateBrowserMinimalisationButton = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnCalibrateSendRunAfterTimeChange = new System.Windows.Forms.Button();
            this._btnCalibrateNexWindowInBar = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabPage();
            this._nUpDown5MinRuns = new System.Windows.Forms.NumericUpDown();
            this._nUpDown15MinRuns = new System.Windows.Forms.NumericUpDown();
            this._nUpDown60MinRuns = new System.Windows.Forms.NumericUpDown();
            this._lab5MinRunTimesText = new System.Windows.Forms.Label();
            this._lab15MinRunTimesText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._btnStartClicker = new System.Windows.Forms.Button();
            this._btnStopClicker = new System.Windows.Forms.Button();
            this._labErrorsMainTab = new System.Windows.Forms.Label();
            this._nUpDownStamine = new System.Windows.Forms.NumericUpDown();
            this._labStaminText = new System.Windows.Forms.Label();
            this._tabControlInMainForm = new System.Windows.Forms.TabControl();
            this.tabCalibration.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDown5MinRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDown15MinRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDown60MinRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDownStamine)).BeginInit();
            this._tabControlInMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOptions
            // 
            this.tabOptions.Location = new System.Drawing.Point(4, 34);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Size = new System.Drawing.Size(434, 855);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Opcje";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // tabCalibration
            // 
            this.tabCalibration.Controls.Add(this._btnCalibrateNexWindowInBar);
            this.tabCalibration.Controls.Add(this._btnCalibrateSendRunAfterTimeChange);
            this.tabCalibration.Controls.Add(this._btnCancel);
            this.tabCalibration.Controls.Add(this._btnCalibrateBrowserMinimalisationButton);
            this.tabCalibration.Controls.Add(this._btnCalibrateMaxBrowserWindow);
            this.tabCalibration.Controls.Add(this._btnCalibrateNextTabInBrowser);
            this.tabCalibration.Controls.Add(this._btnCalibrateTabWombatInBrowser);
            this.tabCalibration.Controls.Add(this._btnCalibrateSixtyMinuteRunBtn);
            this.tabCalibration.Controls.Add(this._btnCalibrateFifteenMinuteRunBtn);
            this.tabCalibration.Controls.Add(this._btnCalibrateFiveMinuteRunBtn);
            this.tabCalibration.Controls.Add(this._btnCalibrateChangeTime);
            this.tabCalibration.Controls.Add(this._btnCalibrateAceptEnedRun);
            this.tabCalibration.Controls.Add(this._labCalibrationButtons);
            this.tabCalibration.Controls.Add(this._btnCalibrateSendRun);
            this.tabCalibration.Location = new System.Drawing.Point(4, 34);
            this.tabCalibration.Name = "tabCalibration";
            this.tabCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalibration.Size = new System.Drawing.Size(434, 855);
            this.tabCalibration.TabIndex = 1;
            this.tabCalibration.Text = "Kalibracja";
            this.tabCalibration.UseVisualStyleBackColor = true;
            // 
            // _btnCalibrateSendRun
            // 
            this._btnCalibrateSendRun.Location = new System.Drawing.Point(25, 66);
            this._btnCalibrateSendRun.Name = "_btnCalibrateSendRun";
            this._btnCalibrateSendRun.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateSendRun.TabIndex = 1;
            this._btnCalibrateSendRun.Text = "Wyslij Wombata";
            this._btnCalibrateSendRun.UseVisualStyleBackColor = true;
            this._btnCalibrateSendRun.Click += new System.EventHandler(this._btnCalibrateSendRun_Click);
            // 
            // _labCalibrationButtons
            // 
            this._labCalibrationButtons.AutoSize = true;
            this._labCalibrationButtons.Location = new System.Drawing.Point(25, 27);
            this._labCalibrationButtons.Name = "_labCalibrationButtons";
            this._labCalibrationButtons.Size = new System.Drawing.Size(228, 25);
            this._labCalibrationButtons.TabIndex = 2;
            this._labCalibrationButtons.Text = "Kalibracja pozycji przycisku:";
            // 
            // _btnCalibrateAceptEnedRun
            // 
            this._btnCalibrateAceptEnedRun.Location = new System.Drawing.Point(25, 122);
            this._btnCalibrateAceptEnedRun.Name = "_btnCalibrateAceptEnedRun";
            this._btnCalibrateAceptEnedRun.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateAceptEnedRun.TabIndex = 3;
            this._btnCalibrateAceptEnedRun.Text = "Potwierdz zakończenie wyprawki";
            this._btnCalibrateAceptEnedRun.UseVisualStyleBackColor = true;
            this._btnCalibrateAceptEnedRun.Click += new System.EventHandler(this._btnCalibrateAceptEnedRun_Click);
            // 
            // _btnCalibrateChangeTime
            // 
            this._btnCalibrateChangeTime.Location = new System.Drawing.Point(25, 178);
            this._btnCalibrateChangeTime.Name = "_btnCalibrateChangeTime";
            this._btnCalibrateChangeTime.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateChangeTime.TabIndex = 4;
            this._btnCalibrateChangeTime.Text = "Zmiana czasu wyprawki";
            this._btnCalibrateChangeTime.UseVisualStyleBackColor = true;
            this._btnCalibrateChangeTime.Click += new System.EventHandler(this._btnCalibrateChangeTime_Click);
            // 
            // _btnCalibrateFiveMinuteRunBtn
            // 
            this._btnCalibrateFiveMinuteRunBtn.Location = new System.Drawing.Point(25, 234);
            this._btnCalibrateFiveMinuteRunBtn.Name = "_btnCalibrateFiveMinuteRunBtn";
            this._btnCalibrateFiveMinuteRunBtn.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateFiveMinuteRunBtn.TabIndex = 5;
            this._btnCalibrateFiveMinuteRunBtn.Text = "5 minut ";
            this._btnCalibrateFiveMinuteRunBtn.UseVisualStyleBackColor = true;
            this._btnCalibrateFiveMinuteRunBtn.Click += new System.EventHandler(this._btnCalibrateFiveMinuteRunBtn_Click);
            // 
            // _btnCalibrateFifteenMinuteRunBtn
            // 
            this._btnCalibrateFifteenMinuteRunBtn.Location = new System.Drawing.Point(25, 291);
            this._btnCalibrateFifteenMinuteRunBtn.Name = "_btnCalibrateFifteenMinuteRunBtn";
            this._btnCalibrateFifteenMinuteRunBtn.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateFifteenMinuteRunBtn.TabIndex = 6;
            this._btnCalibrateFifteenMinuteRunBtn.Text = "15 min";
            this._btnCalibrateFifteenMinuteRunBtn.UseVisualStyleBackColor = true;
            this._btnCalibrateFifteenMinuteRunBtn.Click += new System.EventHandler(this._btnCalibrateFifteenMinuteRunBtn_Click);
            // 
            // _btnCalibrateSixtyMinuteRunBtn
            // 
            this._btnCalibrateSixtyMinuteRunBtn.Location = new System.Drawing.Point(25, 347);
            this._btnCalibrateSixtyMinuteRunBtn.Name = "_btnCalibrateSixtyMinuteRunBtn";
            this._btnCalibrateSixtyMinuteRunBtn.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateSixtyMinuteRunBtn.TabIndex = 7;
            this._btnCalibrateSixtyMinuteRunBtn.Text = "60 min";
            this._btnCalibrateSixtyMinuteRunBtn.UseVisualStyleBackColor = true;
            this._btnCalibrateSixtyMinuteRunBtn.Click += new System.EventHandler(this._btnCalibrateSixtyMinuteRunBtn_Click);
            // 
            // _btnCalibrateTabWombatInBrowser
            // 
            this._btnCalibrateTabWombatInBrowser.Location = new System.Drawing.Point(25, 403);
            this._btnCalibrateTabWombatInBrowser.Name = "_btnCalibrateTabWombatInBrowser";
            this._btnCalibrateTabWombatInBrowser.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateTabWombatInBrowser.TabIndex = 8;
            this._btnCalibrateTabWombatInBrowser.Text = "Tab Wombata w przeglądarce";
            this._btnCalibrateTabWombatInBrowser.UseVisualStyleBackColor = true;
            this._btnCalibrateTabWombatInBrowser.Click += new System.EventHandler(this._btnCalibrateTabWombatInBrowser_Click);
            // 
            // _btnCalibrateNextTabInBrowser
            // 
            this._btnCalibrateNextTabInBrowser.Location = new System.Drawing.Point(25, 460);
            this._btnCalibrateNextTabInBrowser.Name = "_btnCalibrateNextTabInBrowser";
            this._btnCalibrateNextTabInBrowser.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateNextTabInBrowser.TabIndex = 9;
            this._btnCalibrateNextTabInBrowser.Text = "Następny Tab w przeglądarce";
            this._btnCalibrateNextTabInBrowser.UseVisualStyleBackColor = true;
            this._btnCalibrateNextTabInBrowser.Click += new System.EventHandler(this._btnCalibrateNextTabInBrowser_Click);
            // 
            // _btnCalibrateMaxBrowserWindow
            // 
            this._btnCalibrateMaxBrowserWindow.Location = new System.Drawing.Point(25, 517);
            this._btnCalibrateMaxBrowserWindow.Name = "_btnCalibrateMaxBrowserWindow";
            this._btnCalibrateMaxBrowserWindow.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateMaxBrowserWindow.TabIndex = 10;
            this._btnCalibrateMaxBrowserWindow.Text = "Przeglądarka na pasku windowsa";
            this._btnCalibrateMaxBrowserWindow.UseVisualStyleBackColor = true;
            this._btnCalibrateMaxBrowserWindow.Click += new System.EventHandler(this._btnCalibrateMaxBrowserWindow_Click);
            // 
            // _btnCalibrateBrowserMinimalisationButton
            // 
            this._btnCalibrateBrowserMinimalisationButton.Location = new System.Drawing.Point(25, 576);
            this._btnCalibrateBrowserMinimalisationButton.Name = "_btnCalibrateBrowserMinimalisationButton";
            this._btnCalibrateBrowserMinimalisationButton.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateBrowserMinimalisationButton.TabIndex = 11;
            this._btnCalibrateBrowserMinimalisationButton.Text = "Minimalizacja przeglądarki";
            this._btnCalibrateBrowserMinimalisationButton.UseVisualStyleBackColor = true;
            this._btnCalibrateBrowserMinimalisationButton.Click += new System.EventHandler(this._btnCalibrateBrowserMinimalisationButton_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(79, 787);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(234, 44);
            this._btnCancel.TabIndex = 12;
            this._btnCancel.Text = "Anuluj";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnCalibrateSendRunAfterTimeChange
            // 
            this._btnCalibrateSendRunAfterTimeChange.Location = new System.Drawing.Point(25, 639);
            this._btnCalibrateSendRunAfterTimeChange.Name = "_btnCalibrateSendRunAfterTimeChange";
            this._btnCalibrateSendRunAfterTimeChange.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateSendRunAfterTimeChange.TabIndex = 13;
            this._btnCalibrateSendRunAfterTimeChange.Text = "Wysłanie runa po zmianie czasu";
            this._btnCalibrateSendRunAfterTimeChange.UseVisualStyleBackColor = true;
            this._btnCalibrateSendRunAfterTimeChange.Click += new System.EventHandler(this._btnCalibrateSendRunAfterTimeChange_Click);
            // 
            // _btnCalibrateNexWindowInBar
            // 
            this._btnCalibrateNexWindowInBar.Location = new System.Drawing.Point(25, 702);
            this._btnCalibrateNexWindowInBar.Name = "_btnCalibrateNexWindowInBar";
            this._btnCalibrateNexWindowInBar.Size = new System.Drawing.Size(359, 41);
            this._btnCalibrateNexWindowInBar.TabIndex = 14;
            this._btnCalibrateNexWindowInBar.Text = "Następne okno w pasku windowsa";
            this._btnCalibrateNexWindowInBar.UseVisualStyleBackColor = true;
            this._btnCalibrateNexWindowInBar.Click += new System.EventHandler(this._btnCalibrateNextWindowInBar_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this._labStaminText);
            this.tabMain.Controls.Add(this._nUpDownStamine);
            this.tabMain.Controls.Add(this._labErrorsMainTab);
            this.tabMain.Controls.Add(this._btnStopClicker);
            this.tabMain.Controls.Add(this._btnStartClicker);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this._lab15MinRunTimesText);
            this.tabMain.Controls.Add(this._lab5MinRunTimesText);
            this.tabMain.Controls.Add(this._nUpDown60MinRuns);
            this.tabMain.Controls.Add(this._nUpDown15MinRuns);
            this.tabMain.Controls.Add(this._nUpDown5MinRuns);
            this.tabMain.Location = new System.Drawing.Point(4, 34);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(434, 855);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Główna";
            // 
            // _nUpDown5MinRuns
            // 
            this._nUpDown5MinRuns.Location = new System.Drawing.Point(30, 78);
            this._nUpDown5MinRuns.Name = "_nUpDown5MinRuns";
            this._nUpDown5MinRuns.Size = new System.Drawing.Size(136, 31);
            this._nUpDown5MinRuns.TabIndex = 0;
            this._nUpDown5MinRuns.ValueChanged += new System.EventHandler(this._nUpDown5MinRuns_ValueChanged);
            // 
            // _nUpDown15MinRuns
            // 
            this._nUpDown15MinRuns.Location = new System.Drawing.Point(30, 174);
            this._nUpDown15MinRuns.Name = "_nUpDown15MinRuns";
            this._nUpDown15MinRuns.Size = new System.Drawing.Size(136, 31);
            this._nUpDown15MinRuns.TabIndex = 1;
            this._nUpDown15MinRuns.ValueChanged += new System.EventHandler(this._nUpDown15MinRuns_ValueChanged);
            // 
            // _nUpDown60MinRuns
            // 
            this._nUpDown60MinRuns.Location = new System.Drawing.Point(30, 274);
            this._nUpDown60MinRuns.Name = "_nUpDown60MinRuns";
            this._nUpDown60MinRuns.Size = new System.Drawing.Size(136, 31);
            this._nUpDown60MinRuns.TabIndex = 2;
            this._nUpDown60MinRuns.ValueChanged += new System.EventHandler(this._nUpDown60MinRuns_ValueChanged);
            // 
            // _lab5MinRunTimesText
            // 
            this._lab5MinRunTimesText.AutoSize = true;
            this._lab5MinRunTimesText.Location = new System.Drawing.Point(30, 41);
            this._lab5MinRunTimesText.Name = "_lab5MinRunTimesText";
            this._lab5MinRunTimesText.Size = new System.Drawing.Size(118, 25);
            this._lab5MinRunTimesText.TabIndex = 3;
            this._lab5MinRunTimesText.Text = "Ilość % 5 min";
            // 
            // _lab15MinRunTimesText
            // 
            this._lab15MinRunTimesText.AutoSize = true;
            this._lab15MinRunTimesText.Location = new System.Drawing.Point(30, 136);
            this._lab15MinRunTimesText.Name = "_lab15MinRunTimesText";
            this._lab15MinRunTimesText.Size = new System.Drawing.Size(133, 25);
            this._lab15MinRunTimesText.TabIndex = 4;
            this._lab15MinRunTimesText.Text = "Ilość % 15 min ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ilość % 60 min ";
            // 
            // _btnStartClicker
            // 
            this._btnStartClicker.Location = new System.Drawing.Point(30, 369);
            this._btnStartClicker.Name = "_btnStartClicker";
            this._btnStartClicker.Size = new System.Drawing.Size(158, 65);
            this._btnStartClicker.TabIndex = 7;
            this._btnStartClicker.Text = "Start";
            this._btnStartClicker.UseVisualStyleBackColor = true;
            this._btnStartClicker.Click += new System.EventHandler(this._btnStartClicker_Click);
            // 
            // _btnStopClicker
            // 
            this._btnStopClicker.Location = new System.Drawing.Point(207, 369);
            this._btnStopClicker.Name = "_btnStopClicker";
            this._btnStopClicker.Size = new System.Drawing.Size(158, 65);
            this._btnStopClicker.TabIndex = 8;
            this._btnStopClicker.Text = "Stop";
            this._btnStopClicker.UseVisualStyleBackColor = true;
            this._btnStopClicker.Click += new System.EventHandler(this._btnStopClicker_Click);
            // 
            // _labErrorsMainTab
            // 
            this._labErrorsMainTab.AutoSize = true;
            this._labErrorsMainTab.ForeColor = System.Drawing.Color.OrangeRed;
            this._labErrorsMainTab.Location = new System.Drawing.Point(30, 332);
            this._labErrorsMainTab.Name = "_labErrorsMainTab";
            this._labErrorsMainTab.Size = new System.Drawing.Size(0, 25);
            this._labErrorsMainTab.TabIndex = 9;
            // 
            // _nUpDownStamine
            // 
            this._nUpDownStamine.Location = new System.Drawing.Point(207, 78);
            this._nUpDownStamine.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._nUpDownStamine.Name = "_nUpDownStamine";
            this._nUpDownStamine.Size = new System.Drawing.Size(136, 31);
            this._nUpDownStamine.TabIndex = 10;
            this._nUpDownStamine.ValueChanged += new System.EventHandler(this._nUpDownStamine_ValueChanged);
            // 
            // _labStaminText
            // 
            this._labStaminText.AutoSize = true;
            this._labStaminText.Location = new System.Drawing.Point(207, 41);
            this._labStaminText.Name = "_labStaminText";
            this._labStaminText.Size = new System.Drawing.Size(75, 25);
            this._labStaminText.TabIndex = 11;
            this._labStaminText.Text = "Stamina";
            // 
            // _tabControlInMainForm
            // 
            this._tabControlInMainForm.Controls.Add(this.tabMain);
            this._tabControlInMainForm.Controls.Add(this.tabCalibration);
            this._tabControlInMainForm.Controls.Add(this.tabOptions);
            this._tabControlInMainForm.Location = new System.Drawing.Point(3, 12);
            this._tabControlInMainForm.Name = "_tabControlInMainForm";
            this._tabControlInMainForm.SelectedIndex = 0;
            this._tabControlInMainForm.Size = new System.Drawing.Size(442, 893);
            this._tabControlInMainForm.TabIndex = 1;
            // 
            // DobraForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 917);
            this.Controls.Add(this._tabControlInMainForm);
            this.Name = "DobraForma";
            this.Text = "Klikacz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DobraForma_FormClosed);
            this.tabCalibration.ResumeLayout(false);
            this.tabCalibration.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDown5MinRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDown15MinRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDown60MinRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nUpDownStamine)).EndInit();
            this._tabControlInMainForm.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private TabPage tabOptions;
    private TabPage tabCalibration;
    private Button _btnCalibrateNexWindowInBar;
    private Button _btnCalibrateSendRunAfterTimeChange;
    private Button _btnCancel;
    private Button _btnCalibrateBrowserMinimalisationButton;
    private Button _btnCalibrateMaxBrowserWindow;
    private Button _btnCalibrateNextTabInBrowser;
    private Button _btnCalibrateTabWombatInBrowser;
    private Button _btnCalibrateSixtyMinuteRunBtn;
    private Button _btnCalibrateFifteenMinuteRunBtn;
    private Button _btnCalibrateFiveMinuteRunBtn;
    private Button _btnCalibrateChangeTime;
    private Button _btnCalibrateAceptEnedRun;
    private Label _labCalibrationButtons;
    private Button _btnCalibrateSendRun;
    private TabPage tabMain;
    private Label _labStaminText;
    private NumericUpDown _nUpDownStamine;
    private Label _labErrorsMainTab;
    private Button _btnStopClicker;
    private Button _btnStartClicker;
    private Label label1;
    private Label _lab15MinRunTimesText;
    private Label _lab5MinRunTimesText;
    private NumericUpDown _nUpDown60MinRuns;
    private NumericUpDown _nUpDown15MinRuns;
    private NumericUpDown _nUpDown5MinRuns;
    private TabControl _tabControlInMainForm;
}