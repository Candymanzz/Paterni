using System;
using System.Windows.Forms;

public class AddSalesPersonForm : Form
{
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private NumericUpDown numBonus;
    private Button btnOk;
    private Button btnCancel;

    public string FirstName => txtFirstName.Text;
    public string LastName => txtLastName.Text;
    public decimal BonusPerItem => numBonus.Value;

    public AddSalesPersonForm()
    {
        Text = "Добавление продавца";
        Width = 300;
        Height = 250;
        StartPosition = FormStartPosition.CenterParent;

        Label lblFirstName = new Label { Text = "Имя:", Left = 10, Top = 20, Width = 100 };
        txtFirstName = new TextBox { Left = 120, Top = 20, Width = 140 };

        Label lblLastName = new Label { Text = "Фамилия:", Left = 10, Top = 60, Width = 100 };
        txtLastName = new TextBox { Left = 120, Top = 60, Width = 140 };

        Label lblBonus = new Label { Text = "Бонус/товар:", Left = 10, Top = 100, Width = 100 };
        numBonus = new NumericUpDown { Left = 120, Top = 100, Width = 100, DecimalPlaces = 2, Minimum = 0, Maximum = 1000, Value = 0.5M };

        btnOk = new Button { Text = "OK", Left = 50, Top = 150, Width = 80, DialogResult = DialogResult.OK };
        btnCancel = new Button { Text = "Отмена", Left = 150, Top = 150, Width = 80, DialogResult = DialogResult.Cancel };

        Controls.AddRange(new Control[] { lblFirstName, txtFirstName, lblLastName, txtLastName, lblBonus, numBonus, btnOk, btnCancel });
        AcceptButton = btnOk;
        CancelButton = btnCancel;
    }
}
