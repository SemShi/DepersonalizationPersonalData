using DepersonalizationPersonalData.Models.Helpers;
using DepersonalizationPersonalData.Repositories.PersonalizeData;
using Microsoft.Extensions.Configuration;

namespace DepersonalizationPersonalData
{
    public partial class MainForm : Form
    {
        private readonly IConfiguration _cfg;
        private readonly CurrentSession _currentSession;
        private readonly IPersonalizeDataRepository _personalizeDataRepository;

        private PersonalizeData _currentRow;
        private int _currentRowIndex = 0;

        private Dictionary<string, bool> _fields = new Dictionary<string, bool>()
        {
            {$"{nameof(PersonalizeData.FirstName)}", false },
            {$"{nameof(PersonalizeData.MiddleName)}", false },
            {$"{nameof(PersonalizeData.LastName)}", false },
            {$"{nameof(PersonalizeData.Birthday)}", false },
            {$"{nameof(PersonalizeData.Country)}", false },
            {$"{nameof(PersonalizeData.Area)}", false },
            {$"{nameof(PersonalizeData.City)}", false },
            {$"{nameof(PersonalizeData.Phone)}", false },
            {$"{nameof(PersonalizeData.Street)}", false },
            {$"{nameof(PersonalizeData.Home)}", false },
            {$"{nameof(PersonalizeData.Building)}", false },
            {$"{nameof(PersonalizeData.Flat)}", false }
        };

        private void SetDefaultValuesToDictionary()
        {
            foreach (var field in _fields.Keys)
                _fields[field] = false;
        }

        public MainForm(IConfiguration cfg, CurrentSession currentSession, IPersonalizeDataRepository personalizeDataRepository)
        {
            InitializeComponent();
            _cfg = cfg;
            _currentSession = currentSession;
            _personalizeDataRepository = personalizeDataRepository;
            
            splitContainer3.Panel2Collapsed = true;

            tbLastName.TextChanged += UpdateCell;
            tbFirstName.TextChanged += UpdateCell;
            tbMiddleName.TextChanged += UpdateCell;
            tbBirthday.TextChanged += UpdateCell;
            tbCountry.TextChanged += UpdateCell;
            tbArea.TextChanged += UpdateCell;
            tbCity.TextChanged += UpdateCell;
            tbStreet.TextChanged += UpdateCell;
            tbHome.TextChanged += UpdateCell;
            tbBuilding.TextChanged += UpdateCell;
            tbFlat.TextChanged += UpdateCell;
            tbPhone.TextChanged += UpdateCell;
        }



        private async void btSignUp_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();
            (bool isSuccess, string message) = await _currentSession.ActivateSession(login, password);
            if (isSuccess)
            {
                ChangeStatus(true);
                ShowHideLoginPanel();
                LoadTable();
            }
            else
                rtbInfo.Text = message;
        }

        private void ShowHideLoginPanel(bool show = false)
        {
            if (show)
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
                splitContainer3.Panel2Collapsed = true;
                splitContainer3.Panel2.Hide();
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Hide();
                splitContainer3.Panel2Collapsed = false;
                splitContainer3.Panel2.Show();
            }
        }

        private void ChangeStatus(bool signedUp)
        {
            if (signedUp)
            {
                this.Text += " | " + _currentSession!.CurrentUser!.Login;
                tsLabel.Text = _currentSession!.CurrentUser!.Name;
            }
            else
            {
                this.Text = "Обезличивание персональных данных";
                tsLabel.Text = "Войдите в систему";
            }
        }

        private void msChangeUser_Click(object sender, EventArgs e)
        {
            _currentSession.DeActivateSession();
            tbPassword.Text = string.Empty;
            dgvPersonalizeData.Columns.Clear();
            ChangeStatus(false);
            ShowHideLoginPanel(true);

            tbCountry.Text = string.Empty;
            tbArea.Text = string.Empty;
            tbCity.Text = string.Empty;
            tbStreet.Text = string.Empty;
            tbHome.Text = string.Empty;
            tbBuilding.Text = string.Empty;
            tbFlat.Text = string.Empty;
            tbPhone.Text = string.Empty;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

        }

        private void FillDictionary(PersonalizeData model)
        {
            if (model == null) return;

            if (!string.IsNullOrWhiteSpace(model.FirstName))
                _fields[nameof(model.FirstName)] = true;
            if (!string.IsNullOrWhiteSpace(model.LastName))
                _fields[nameof(model.LastName)] = true;
            if (!string.IsNullOrWhiteSpace(model.MiddleName))
                _fields[nameof(model.MiddleName)] = true;
            if (!string.IsNullOrWhiteSpace(model.BirthDayToDataBaseFormat) || model.BirthDayToDataBaseFormat != "0001-01-01")
                _fields[nameof(model.Birthday)] = true;
            if (!string.IsNullOrWhiteSpace(model.Country))
                _fields[nameof(model.Country)] = true;
            if (!string.IsNullOrWhiteSpace(model.Area))
                _fields[nameof(model.Area)] = true;
            if (!string.IsNullOrWhiteSpace(model.City))
                _fields[nameof(model.City)] = true;
            if (!string.IsNullOrWhiteSpace(model.Phone))
                _fields[nameof(model.Phone)] = true;
            if (!string.IsNullOrWhiteSpace(model.Street))
                _fields[nameof(model.Street)] = true;
            if (model.Home != 0)
                _fields[nameof(model.Home)] = true;
            if (!string.IsNullOrWhiteSpace(model.Building))
                _fields[nameof(model.Building)] = true;
            if (model.Flat != 0)
                _fields[nameof(model.Flat)] = true;
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            var model = new PersonalizeData();
            bool isGuidExists = ((PersonalizeData)dgvPersonalizeData.CurrentRow.DataBoundItem).Data_id == Guid.Empty ? false : true;
            if (!isGuidExists)
                model.Data_id = Guid.NewGuid();
            else
                model.Data_id = ((PersonalizeData)dgvPersonalizeData.CurrentRow.DataBoundItem).Data_id;
            model.LastName = tbLastName.Text;
            model.FirstName = tbFirstName.Text;
            model.MiddleName = tbMiddleName.Text;
            model.Birthday = !DateTime.TryParse(tbBirthday.Text, out DateTime birth) ? DateTime.MinValue : birth;
            model.Country = tbCountry.Text;
            model.Area = tbArea.Text;
            model.City = tbCity.Text;
            model.Street = tbStreet.Text;
            model.Home = !int.TryParse(tbHome.Text, out int home) ? 0 : home;
            model.Building = string.IsNullOrWhiteSpace(tbBuilding.Text) ? "" : tbBuilding.Text;
            model.Flat = !int.TryParse(tbFlat.Text, out int flat) ? 0 : flat;
            model.Phone = tbPhone.Text;

            bool result = false;
            FillDictionary(model);
            if (isGuidExists)
                result = await _personalizeDataRepository.UpdatePersonaliezeData(model, _fields);
            else
                result = await _personalizeDataRepository.InsertPersonaliezeData(model);

            if (result)
            {
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
            }
            SetDefaultValuesToDictionary();    
        }

        private async void LoadTable()
        {
            dgvPersonalizeData.Columns.Clear();
            AddTextBoxColumn(dgvPersonalizeData, 0, "Фамилия", "LastName", "LastName", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 1, "Имя", "FirstName", "FirstName", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 2, "Отчество", "MiddleName", "MiddleName", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 3, "Дата рождения", "Birthday", "Birthday", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 4, "Страна", "Country", "Country", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 5, "Область", "Area", "Area", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 6, "Город", "City", "City", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 7, "Улица", "Street", "Street", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 8, "Дом", "Home", "Home", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 9, "Корпус", "Building", "Building", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 10, "Квартира", "Flat", "Flat", 100, true);
            AddTextBoxColumn(dgvPersonalizeData, 11, "Телефон", "Phone", "Phone", 100, true);

            var data = await _personalizeDataRepository.GetAllPeronalizeData(Guid.Empty, _currentSession.CurrentUser!.IsUserCanSeeAllData());
            dgvPersonalizeData.DataSource = data;

            if (!data.Any()) return;
            _currentRow = data.First();
            FillEditMenu(_currentSession.CurrentUser!.IsUserCanSeeAllData());
        }

        private void FillEditMenu(bool allData)
        {
            tbLastName.Text = _currentRow.LastName;
            tbFirstName.Text = _currentRow.FirstName;
            tbMiddleName.Text = _currentRow.MiddleName;
            tbBirthday.Text = _currentRow.Birthday.ToShortDateString();
            if (allData)
            {
                tbCountry.Text = _currentRow.Country;
                tbArea.Text = _currentRow.Area;
                tbCity.Text = _currentRow.City;
                tbStreet.Text = _currentRow.Street;
                tbHome.Text = _currentRow.Home.ToString();
                tbBuilding.Text = _currentRow.Building;
                tbFlat.Text = _currentRow.Flat.ToString();
                tbPhone.Text = _currentRow.Phone;
            }
            else
            {
                tbCountry.PlaceholderText = "Информация недоступна";
                tbArea.PlaceholderText = "Информация недоступна";
                tbCity.PlaceholderText = "Информация недоступна";
                tbStreet.PlaceholderText = "Информация недоступна";
                tbHome.PlaceholderText = "Информация недоступна";
                tbBuilding.PlaceholderText = "Информация недоступна";
                tbFlat.PlaceholderText = "Информация недоступна";
                tbPhone.PlaceholderText = "Информация недоступна";
            }
            
        }

        private void dgvPersonalizeData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvPersonalizeData.Columns[e.ColumnIndex].DisplayIndex)
            {
                case 0:
                    tbLastName.Focus();
                    break;
                case 1:
                    tbFirstName.Focus();
                    break;
                case 2:
                    tbMiddleName.Focus();
                    break;
                case 3:
                    tbBirthday.Focus();
                    break;
                case 4:
                    tbCountry.Focus();
                    break;
                case 5:
                    tbArea.Focus();
                    break;
                case 6:
                    tbCity.Focus();
                    break;
                case 7:
                    tbStreet.Focus();
                    break;
                case 8:
                    tbHome.Focus();
                    break;
                case 9:
                    tbBuilding.Focus();
                    break;
                case 10:
                    tbFlat.Focus();
                    break;
                case 11:
                    tbPhone.Focus();
                    break;
            }
            if ((PersonalizeData)dgvPersonalizeData.Rows[e.RowIndex].DataBoundItem == _currentRow) return;
            _currentRowIndex = e.RowIndex;
            _currentRow = (PersonalizeData)dgvPersonalizeData.Rows[e.RowIndex].DataBoundItem;
            FillEditMenu(_currentSession.CurrentUser!.IsUserCanSeeAllData());
        }

        private void UpdateCell(object sender, EventArgs e)
        {
            if(dgvPersonalizeData.Rows.Count == 0) return;
            switch (((TextBox)sender).Name)
            {
                case "tbLastName":
                    dgvPersonalizeData.CurrentRow.Cells["LastName"].Value = ((TextBox)sender).Text;
                    break;
                case "tbFirstName":
                    dgvPersonalizeData.CurrentRow.Cells["FirstName"].Value = ((TextBox)sender).Text;
                    break;
                case "tbMiddleName":
                    dgvPersonalizeData.CurrentRow.Cells["MiddleName"].Value = ((TextBox)sender).Text;
                    break;
                case "tbBirthday":
                    dgvPersonalizeData.CurrentRow.Cells["Birthday"].Value = ((TextBox)sender).Text;
                    break;
                case "tbCountry":
                    dgvPersonalizeData.CurrentRow.Cells["Country"].Value = ((TextBox)sender).Text;
                    break;
                case "tbArea":
                    dgvPersonalizeData.CurrentRow.Cells["Area"].Value = ((TextBox)sender).Text;
                    break;
                case "tbCity":
                    dgvPersonalizeData.CurrentRow.Cells["City"].Value = ((TextBox)sender).Text;
                    break;
                case "tbStreet":
                    dgvPersonalizeData.CurrentRow.Cells["Street"].Value = ((TextBox)sender).Text;
                    break;
                case "tbHome":
                    dgvPersonalizeData.CurrentRow.Cells["Home"].Value = ((TextBox)sender).Text;
                    break;
                case "tbBuilding":
                    dgvPersonalizeData.CurrentRow.Cells["Building"].Value = ((TextBox)sender).Text;
                    break;
                case "tbFlat":
                    dgvPersonalizeData.CurrentRow.Cells["Flat"].Value = ((TextBox)sender).Text;
                    break;
                case "tbPhone":
                    dgvPersonalizeData.CurrentRow.Cells["Phone"].Value = ((TextBox)sender).Text;
                    break;

            }
        }

        public void AddTextBoxColumn(DataGridView dataGridView, int colNum, string header, string name, string dataPropertyName, int width, bool readOnly)
        {
            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.Width = width;
            textBoxColumn.HeaderText = header;
            textBoxColumn.Name = name;
            textBoxColumn.ReadOnly = readOnly;
            textBoxColumn.DataPropertyName = dataPropertyName;
            dataGridView.Columns.Insert(colNum, textBoxColumn);
        }

        
    }
}