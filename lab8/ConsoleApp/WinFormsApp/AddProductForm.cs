using System;
using System.Windows.Forms;

public class AddProductForm : Form
{
    private TextBox txtName;
    private NumericUpDown numPrice;
    private NumericUpDown numQty;
    private Button btnOk;
    private Button btnCancel;

    public string ProductName => txtName.Text;
    public decimal Price => numPrice.Value;
    public int Quantity => (int)numQty.Value;

    public AddProductForm()
    {
        Text = "Добавление товара";
        Width = 300;
        Height = 250;
        StartPosition = FormStartPosition.CenterParent;

        Label lblName = new Label { Text = "Название:", Left = 10, Top = 20, Width = 100 };
        txtName = new TextBox { Left = 120, Top = 20, Width = 140 };

        Label lblPrice = new Label { Text = "Цена:", Left = 10, Top = 60, Width = 100 };
        numPrice = new NumericUpDown { Left = 120, Top = 60, Width = 100, DecimalPlaces = 2, Minimum = 0, Maximum = 100000 };

        Label lblQty = new Label { Text = "Количество:", Left = 10, Top = 100, Width = 100 };
        numQty = new NumericUpDown { Left = 120, Top = 100, Width = 100, Minimum = 1, Maximum = 1000, Value = 1 };

        btnOk = new Button { Text = "OK", Left = 50, Top = 150, Width = 80, DialogResult = DialogResult.OK };
        btnCancel = new Button { Text = "Отмена", Left = 150, Top = 150, Width = 80, DialogResult = DialogResult.Cancel };

        Controls.AddRange(new Control[] { lblName, txtName, lblPrice, numPrice, lblQty, numQty, btnOk, btnCancel });
        AcceptButton = btnOk;
        CancelButton = btnCancel;
    }
}
