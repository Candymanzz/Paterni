using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private Mixer _mixer;
    private Label lblState;
    private Button btnTurnOpen;
    private Button btnTurnClose;
    private Button btnSwitchSpout;
    private Button btnSwitchShower;
    private Button btnRestore;

    public Form1()
    {
        Text = "Mixer State Demo";
        Size = new Size(420, 200);

        _mixer = new Mixer(failureProb: 0.12); // чуть выше вероятность отказа для демонстрации

        lblState = new Label { Left = 10, Top = 10, Width = 380, Text = "State: " + _mixer.StateName };
        btnTurnOpen = new Button { Left = 10, Top = 40, Width = 120, Text = "Open (angle=30)" };
        btnTurnClose = new Button { Left = 140, Top = 40, Width = 120, Text = "Close (angle=0)" };
        btnSwitchSpout = new Button { Left = 10, Top = 80, Width = 120, Text = "Switch to Spout" };
        btnSwitchShower = new Button { Left = 140, Top = 80, Width = 120, Text = "Switch to Shower" };
        btnRestore = new Button { Left = 270, Top = 40, Width = 120, Text = "Restore Water" };

        btnTurnOpen.Click += (s, e) => { _mixer.Turn(30, "cold"); UpdateState(); };
        btnTurnClose.Click += (s, e) => { _mixer.Turn(0, "cold"); UpdateState(); };
        btnSwitchSpout.Click += (s, e) => { _mixer.SwitchToSpout(); UpdateState(); };
        btnSwitchShower.Click += (s, e) => { _mixer.SwitchToShower(); UpdateState(); };
        btnRestore.Click += (s, e) => { _mixer.RestoreWater(); UpdateState(); };

        Controls.Add(lblState);
        Controls.Add(btnTurnOpen);
        Controls.Add(btnTurnClose);
        Controls.Add(btnSwitchSpout);
        Controls.Add(btnSwitchShower);
        Controls.Add(btnRestore);
    }

    private void UpdateState()
    {
        lblState.Text = "State: " + _mixer.StateName;
        // Подсказка пользователю
        if (_mixer.StateName == "NoWater")
        {
            MessageBox.Show("No water — выполните RestoreWater()", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}