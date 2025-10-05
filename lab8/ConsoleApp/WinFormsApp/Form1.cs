using ClassLibary;

public class MainForm : Form
{
    private Store store = new Store();

    private DataGridView dgvProducts;
    private DataGridView dgvSalesPersons;
    private Button btnAddProduct;
    private Button btnAddSP;
    private Button btnSave;
    private Button btnLoad;

    public MainForm()
    {
        Text = "Магазин (WinForms)"; Width = 900; Height = 600;

        dgvProducts = new DataGridView { Left = 10, Top = 10, Width = 420, Height = 400, ReadOnly = true, AutoGenerateColumns = true };
        dgvSalesPersons = new DataGridView { Left = 440, Top = 10, Width = 420, Height = 400, ReadOnly = true, AutoGenerateColumns = true };

        btnAddProduct = new Button { Left = 10, Top = 420, Width = 130, Text = "Добавить товар" };
        btnAddSP = new Button { Left = 150, Top = 420, Width = 130, Text = "Добавить продавца" };
        btnSave = new Button { Left = 440, Top = 420, Width = 130, Text = "Сохранить в XML" };
        btnLoad = new Button { Left = 580, Top = 420, Width = 130, Text = "Загрузить из XML" };

        btnAddProduct.Click += BtnAddProduct_Click!;
        btnAddSP.Click += BtnAddSP_Click!;
        btnSave.Click += BtnSave_Click!;
        btnLoad.Click += BtnLoad_Click!;

        Controls.AddRange(new Control[] { dgvProducts, dgvSalesPersons, btnAddProduct, btnAddSP, btnSave, btnLoad });

        RefreshGrids();
    }

    private void RefreshGrids()
    {
        dgvProducts.DataSource = null;
        dgvProducts.DataSource = store.Products;

        dgvSalesPersons.DataSource = null;
        dgvSalesPersons.DataSource = store.SalesPersons;
    }

    private void BtnAddProduct_Click(object sender, EventArgs e)
    {
        var dlg = new AddProductForm();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            store.AddProduct(new Product(dlg.ProductName, dlg.Price, dlg.Quantity));
            RefreshGrids();
        }
    }

    private void BtnAddSP_Click(object sender, EventArgs e)
    {
        var dlg = new AddSalesPersonForm();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            store.AddSalesPerson(new SalesPerson(dlg.FirstName, dlg.LastName, dlg.BonusPerItem));
            RefreshGrids();
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        var sfd = new SaveFileDialog { Filter = "XML files|*.xml", FileName = "store_data.xml" };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            store.SaveToXml(sfd.FileName);
            MessageBox.Show("Сохранено");
        }
    }

    private void BtnLoad_Click(object sender, EventArgs e)
    {
        var ofd = new OpenFileDialog { Filter = "XML files|*.xml" };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            store = Store.LoadFromXml(ofd.FileName);
            RefreshGrids();
            MessageBox.Show("Загружено");
        }
    }
}
