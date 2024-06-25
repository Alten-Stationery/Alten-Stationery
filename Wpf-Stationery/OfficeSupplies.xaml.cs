using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for OfficeSupplies.xaml
    /// </summary>
    public partial class OfficeSupplies : Window
    {

        DataTable dtExcel = new DataTable();
        DataRow dr = null;

        public OfficeSupplies()
        {
            InitializeComponent();
            LoadData();
        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  

            //#region Load - GetAll
            //try
            //{
            //    //DataTable dtExcel = new DataTable();
            //    dtExcel = new DataTable();

            //    dtExcel = ReadExcelDataTable(filePath, fileExt); //read excel file  

            //    if (dtExcel != null)
            //    {
            //        //Ridimensiona();
            //        CustomerGrid.Visibility = Visibility.Visible;

            //        //Set the DataGrid's DataContext to be a filled DataTable
            //        CustomerGrid.DataContext = dtExcel;
            //    }
            //    //webBrowser.NavigateToString(dtExcel.ToString());
            //}catch
            //{

            //}       
            //#endregion

        }


        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackToHomeButton_Click(object sender, RoutedEventArgs e)
        {

        }


        //public DataTable ReadExcelDataTable(string fileName, string fileExt)
        //{
        //    string conn = string.Empty;

        //    this.TxtPercorsoFile.Text = fileName;
        //    //List<fatturaPorteseSolC> listaMisureExcel = new List<fatturaPorteseSolC>();
        //    listaMisureExcel = new List<fatturaPorteseSolC>();

        //    //DataTable dtExcel = new DataTable();
        //    // Make a DataTable using the function below.
        //    DataTable dtExcel = MakeTableWithAutoIncrement();

        //    //DataRow dr;
        //    dr = null;
        //    // Declare the array variable.
        //    //object[] rowArray = new object[15];

        //    if (fileExt.CompareTo(".xlsx") == 0)
        //    {
        //        Dictionary<Tuple<int, int>, object> data = new Dictionary<Tuple<int, int>, object>();
        //        using (XLWorkbook wb = new XLWorkbook(fileName))
        //        {
        //            var ws = wb.Worksheets.First();
        //            var range = ws.RangeUsed();

        //            if (range.ColumnCount() + 1 == 16)
        //            {
        //                for (int i = 2; i < range.RowCount() + 1; i++)
        //                {

        //                    //for (int j = 1; j < range.ColumnCount() + 1; j++)
        //                    //{
        //                    //	data.Add(new Tuple<int, int>(i, j), ws.Cell(i, j).Value);
        //                    //}

        //                    //Mappare l'oggetto fatturaPorteseSolC con i dati dell'excel
        //                    #region Mappo le letture 
        //                    fatturaPorteseSolC f = new fatturaPorteseSolC();

        //                    f.tipoConsumo = ws.Cell(i, 1).Value.ToString();
        //                    if (f.tipoConsumo.Equals(""))
        //                    {
        //                        f.tipoConsumo = "A";
        //                    }

        //                    f.codiceLettura = ws.Cell(i, 2).Value.ToString();

        //                    f.periodoDataCEO = ws.Cell(i, 3).Value.ToString();
        //                    //if (!String.IsNullOrEmpty(f.periodoDataCEO))
        //                    //{
        //                    //	string secondadata = (f.periodoDataCEO).Substring(11);
        //                    //	f.dataLettura = Convert.ToDateTime(secondadata);
        //                    //}
        //                    //else
        //                    //{
        //                    //	f.dataLettura = Convert.ToDateTime(ws.Cell(i, 3).Value.ToString());
        //                    //}

        //                    try
        //                    {
        //                        f.dataLettura = Convert.ToDateTime(ws.Cell(i, 4).Value.ToString());
        //                        //if (this.DataLetturaCheck.IsChecked == true)
        //                        //{
        //                        //	f.dataLettura = f.dataLettura.AddDays(-1);
        //                        //}
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        f.dataLettura = DateTime.MinValue;
        //                        MessageBox.Show("La data lettura deve avere il formato GG/MM/AAAA e non può essere vuota!!!", "Errori data lettura", MessageBoxButton.OK, MessageBoxImage.Error);
        //                        return null;
        //                    }

        //                    f.attivaF1 = ws.Cell(i, 5).Value.ToString();
        //                    if (f.attivaF1.Equals("")) { f.attivaF1 = "0"; }

        //                    f.attivaF2 = ws.Cell(i, 6).Value.ToString();
        //                    if (f.attivaF2.Equals("")) { f.attivaF2 = "0"; }

        //                    f.attivaF3 = ws.Cell(i, 7).Value.ToString();
        //                    if (f.attivaF3.Equals("")) { f.attivaF3 = "0"; }

        //                    f.reattivaF1 = ws.Cell(i, 8).Value.ToString();
        //                    if (f.reattivaF1.Equals("")) { f.reattivaF1 = "0"; }
        //                    f.reattivaF2 = ws.Cell(i, 9).Value.ToString();
        //                    if (f.reattivaF2.Equals("")) { f.reattivaF2 = "0"; }
        //                    f.reattivaF3 = ws.Cell(i, 10).Value.ToString();
        //                    if (f.reattivaF3.Equals("")) { f.reattivaF3 = "0"; }

        //                    f.potenzaF1 = ws.Cell(i, 11).Value.ToString();
        //                    if (f.potenzaF1.Equals("")) { f.potenzaF1 = "0"; }
        //                    f.potenzaF2 = ws.Cell(i, 12).Value.ToString();
        //                    if (f.potenzaF2.Equals("")) { f.potenzaF2 = "0"; }
        //                    f.potenzaF3 = ws.Cell(i, 13).Value.ToString();
        //                    if (f.potenzaF3.Equals("")) { f.potenzaF3 = "0"; }

        //                    int potenzaF1 = 0;
        //                    int potenzaF2 = 0;
        //                    int potenzaF3 = 0;

        //                    double dPotenza1 = Double.Parse(f.potenzaF1);
        //                    double dPotenza2 = Double.Parse(f.potenzaF2);
        //                    double dPotenza3 = Double.Parse(f.potenzaF3);
        //                    if (dPotenza1 == dPotenza2 && dPotenza1 == dPotenza3)
        //                    {
        //                        f.potenzaMax = dPotenza1 + "";
        //                    }
        //                    else
        //                    {
        //                        double[] potenze = { dPotenza1, dPotenza2, dPotenza3 };
        //                        f.potenzaMax = potenze.Max() + "";
        //                    }

        //                    f.matricolaMisuratore = ws.Cell(i, 14).Value.ToString();
        //                    if (f.matricolaMisuratore.Equals("")) { f.matricolaMisuratore = "00000000"; }
        //                    else if (f.matricolaMisuratore.Length <= 8)
        //                    {
        //                        int lengthMatricola = 8 - f.matricolaMisuratore.Length;
        //                        for (int x = 0; x < lengthMatricola; x++)
        //                        {
        //                            f.matricolaMisuratore = "0" + f.matricolaMisuratore;
        //                        }
        //                    }
        //                    else if (f.matricolaMisuratore.Length > 8)
        //                    {
        //                        MessageBox.Show("La Matricola Misuratore deve avere massimo 8 caratteri!!!", "Errori Matricola Misuratore", MessageBoxButton.OK, MessageBoxImage.Error);
        //                        return null;
        //                    }
        //                    f.codiceMisuratore = ws.Cell(i, 15).Value.ToString();
        //                    if (f.codiceMisuratore.Equals("")) { f.codiceMisuratore = "000000000"; }
        //                    else if (f.codiceMisuratore.Length <= 9)
        //                    {
        //                        int lengthCodMisuratore = 9 - f.codiceMisuratore.Length;
        //                        for (int y = 0; y < lengthCodMisuratore; y++)
        //                        {
        //                            f.codiceMisuratore = "0" + f.codiceMisuratore;
        //                        }
        //                    }
        //                    else if (f.codiceMisuratore.Length > 9)
        //                    {
        //                        MessageBox.Show("Il Codice Misuratore deve avere massimo 9 caratteri!!!", "Errori Codice Misuratore", MessageBoxButton.OK, MessageBoxImage.Error);
        //                        return null;
        //                    }

        //                    //f.costante = ws.Cell(i, 14).Value.ToString();
        //                    //f.segnalazione = ws.Cell(i, 15).Value.ToString();
        //                    //f.stringaDataRicezione = ws.Cell(i, 16).Value.ToString();
        //                    //f.descrizioneStato = ws.Cell(i, 17).Value.ToString();
        //                    //f.matricolaOperatore = ws.Cell(i, 18).Value.ToString();

        //                    f.provenienza = Costanti.LETTURE_FROM_EXCEL;
        //                    f.colore = Costanti.COLORE_LETTURE_EXCEL;
        //                    f.modifica = true;

        //                    // Convalida cifre numeriche ...
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.attivaF1, Costanti.TIPO_VALORE_INTEGER, "Energia A1"); } catch (FatturazioneException fe) { f.attivaF1 = (Decimal.Truncate(Convert.ToDecimal(f.attivaF1))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.attivaF2, Costanti.TIPO_VALORE_INTEGER, "Energia A2"); } catch (FatturazioneException fe) { f.attivaF2 = (Decimal.Truncate(Convert.ToDecimal(f.attivaF2))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.attivaF3, Costanti.TIPO_VALORE_INTEGER, "Energia A3"); } catch (FatturazioneException fe) { f.attivaF3 = (Decimal.Truncate(Convert.ToDecimal(f.attivaF3))).ToString(); }

        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.reattivaF1, Costanti.TIPO_VALORE_INTEGER, "Energia R1"); } catch (FatturazioneException fe) { f.reattivaF1 = (Decimal.Truncate(Convert.ToDecimal(f.reattivaF1))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.reattivaF2, Costanti.TIPO_VALORE_INTEGER, "Energia R2"); } catch (FatturazioneException fe) { f.reattivaF2 = (Decimal.Truncate(Convert.ToDecimal(f.reattivaF2))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.reattivaF3, Costanti.TIPO_VALORE_INTEGER, "Energia R3"); } catch (FatturazioneException fe) { f.reattivaF3 = (Decimal.Truncate(Convert.ToDecimal(f.reattivaF3))).ToString(); }

        //                    //Le setto solo per calcolare la Potenza Massima, attualmente non sono presenti nell'Elenco ad esclusione della P.Max
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.potenzaF1, Costanti.TIPO_VALORE_INTEGER, "Potenza F1"); } catch (FatturazioneException fe) { f.potenzaF1 = (Decimal.Truncate(Convert.ToDecimal(f.potenzaF1))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.potenzaF2, Costanti.TIPO_VALORE_INTEGER, "Potenza F2"); } catch (FatturazioneException fe) { f.potenzaF2 = (Decimal.Truncate(Convert.ToDecimal(f.potenzaF2))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.potenzaF3, Costanti.TIPO_VALORE_INTEGER, "Potenza F3"); } catch (FatturazioneException fe) { f.potenzaF3 = (Decimal.Truncate(Convert.ToDecimal(f.potenzaF3))).ToString(); }
        //                    try { FatturazioneHelper.Instance.ConvalidaValore(f.potenzaMax, Costanti.TIPO_VALORE_INTEGER, "Potenza MAX"); } catch (FatturazioneException fe) { f.potenzaMax = (Decimal.Truncate(Convert.ToDecimal(f.potenzaMax))).ToString(); }

        //                    //MessageBox.Show(fe.Message, "Errori inserisci lettura", MessageBoxButton.OK, MessageBoxImage.Error);

        //                    // Convalida date lettura e ricezione ...
        //                    //if (f.dataLettura == DateTime.MinValue;)
        //                    //{
        //                    //	MessageBox.Show("La data lettura non può essere vuota", "Errori data lettura", MessageBoxButton.OK, MessageBoxImage.Error);
        //                    //}

        //                    #endregion

        //                    #region Gestione Righe Data Table
        //                    ////A o R
        //                    //rowArray[0] = ws.Cell(i, 1).Value.ToString();
        //                    ////Codice lettura
        //                    //rowArray[1] = ws.Cell(i, 2).Value.ToString();
        //                    ////Periodo CEO
        //                    //rowArray[2] = ws.Cell(i, 3).Value.ToString();
        //                    ////Data lettura
        //                    //rowArray[3] = ws.Cell(i, 4).Value.ToString();
        //                    ////A1
        //                    //rowArray[4] = ws.Cell(i, 5).Value.ToString();
        //                    ////A2
        //                    //rowArray[5] = ws.Cell(i, 6).Value.ToString();
        //                    ////A3
        //                    //rowArray[6] = ws.Cell(i, 7).Value.ToString();
        //                    ////R1
        //                    //rowArray[7] = ws.Cell(i, 8).Value.ToString();
        //                    ////R2
        //                    //rowArray[8] = ws.Cell(i, 9).Value.ToString();
        //                    ////R3
        //                    //rowArray[9] = ws.Cell(i, 10).Value.ToString();
        //                    ////P1
        //                    //rowArray[10] = ws.Cell(i, 11).Value.ToString();
        //                    ////P2
        //                    //rowArray[11] = ws.Cell(i, 12).Value.ToString();
        //                    ////P3
        //                    //rowArray[12] = ws.Cell(i, 13).Value.ToString();
        //                    ////Matricola
        //                    //rowArray[13] = ws.Cell(i, 14).Value.ToString();
        //                    ////Cod.Misuratore
        //                    //rowArray[14] = ws.Cell(i, 15).Value.ToString();
        //                    #endregion

        //                    #region mapping data table visivo
        //                    //A o R
        //                    rowArray[0] = f.tipoConsumo;
        //                    rowArray[1] = f.codiceLettura;
        //                    rowArray[2] = f.periodoDataCEO;
        //                    rowArray[3] = f.dataLettura;
        //                    rowArray[4] = f.attivaF1;
        //                    rowArray[5] = f.attivaF2;
        //                    rowArray[6] = f.attivaF3;
        //                    rowArray[7] = f.reattivaF1;
        //                    rowArray[8] = f.reattivaF2;
        //                    rowArray[9] = f.reattivaF3;
        //                    rowArray[10] = f.potenzaF1;
        //                    rowArray[11] = f.potenzaF2;
        //                    rowArray[12] = f.potenzaF3;
        //                    rowArray[13] = f.matricolaMisuratore;
        //                    rowArray[14] = f.codiceMisuratore;
        //                    #endregion

        //                    dr = dtExcel.NewRow();
        //                    dr.ItemArray = rowArray;
        //                    dtExcel.Rows.Add(dr);

        //                    listaMisureExcel.Add(f);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Numero di colonne ERRATO!!!\nUtilizzare il file MASTER scaricato dalla Modale!\nLe colonne devono essere 16.\nAttualmente ne sono: " + dtExcel.Columns.Count, "ERRORE COLONNE", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //            if (listaMisureExcel == null)
        //            {
        //                if (listaMisureExcel.Count() > 0)
        //                {
        //                    MessageBox.Show("File vuoto!!!", "Contenuto file importato", MessageBoxButton.OK, MessageBoxImage.Information);
        //                }
        //            }
        //            //PrintTable(dtExcel);
        //        }
        //    }

        //    #region XLS - OLEDB
        //    else if (fileExt.CompareTo(".xls") == 0)
        //    {
        //        conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  

        //        //else if (fileExt.CompareTo(".xlsx") == 0)
        //        //{
        //        //	conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007 

        //        //	//conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0 Macro;HDR=YES\";"; ;
        //        //	//conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
        //        //	//conn = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + fileName + "; Extended Properties='Excel 8.0; HDR=no;'";
        //        //	//conn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=Yes';Data Source=" + fileName);
        //        //}
        //        using (OleDbConnection con = new OleDbConnection(conn))
        //        {
        //            OleDbDataAdapter oleAdpt = null;
        //            try
        //            {
        //                oleAdpt = new OleDbDataAdapter("select * from [Foglio1$]", con); //here we read data from sheet1  
        //                oleAdpt.Fill(dtExcel); //fill excel data into dataTable  
        //            }
        //            catch (Exception ex) { }

        //            if (dtExcel != null)
        //            {
        //                if (dtExcel.Columns.Count + 1 == 16)
        //                {
        //                    if (dtExcel.Rows.Count > 0)
        //                    {
        //                        foreach (var item in dtExcel.Rows)
        //                        {
        //                            //Mappare l'oggetto fatturaPorteseSolC con i dati dell'excel
        //                            #region Mappo le letture 
        //                            fatturaPorteseSolC f = new fatturaPorteseSolC();

        //                            f.tipoConsumo = ((System.Data.DataRow)item).ItemArray[0].ToString();
        //                            if (f.tipoConsumo.Equals(""))
        //                            {
        //                                f.tipoConsumo = "A";
        //                            }

        //                            f.codiceLettura = ((System.Data.DataRow)item).ItemArray[1].ToString();

        //                            f.periodoDataCEO = ((System.Data.DataRow)item).ItemArray[2].ToString();

        //                            try
        //                            {
        //                                f.dataLettura = Convert.ToDateTime(((System.Data.DataRow)item).ItemArray[3].ToString());
        //                                //if (this.DataLetturaCheck.IsChecked == true)
        //                                //{
        //                                //	f.dataLettura = f.dataLettura.AddDays(-1);
        //                                //}
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                f.dataLettura = DateTime.MinValue;
        //                            }

        //                            f.attivaF1 = ((System.Data.DataRow)item).ItemArray[4].ToString();
        //                            if (f.attivaF1.Equals("")) { f.attivaF1 = "0"; }

        //                            f.attivaF2 = ((System.Data.DataRow)item).ItemArray[5].ToString();
        //                            if (f.attivaF2.Equals("")) { f.attivaF2 = "0"; }

        //                            f.attivaF3 = ((System.Data.DataRow)item).ItemArray[6].ToString();
        //                            if (f.attivaF3.Equals("")) { f.attivaF3 = "0"; }

        //                            f.reattivaF1 = ((System.Data.DataRow)item).ItemArray[7].ToString();
        //                            if (f.reattivaF1.Equals("")) { f.reattivaF1 = "0"; }
        //                            f.reattivaF2 = ((System.Data.DataRow)item).ItemArray[8].ToString();
        //                            if (f.reattivaF2.Equals("")) { f.reattivaF2 = "0"; }
        //                            f.reattivaF3 = ((System.Data.DataRow)item).ItemArray[9].ToString();
        //                            if (f.reattivaF3.Equals("")) { f.reattivaF3 = "0"; }

        //                            f.potenzaF1 = ((System.Data.DataRow)item).ItemArray[10].ToString();
        //                            if (f.potenzaF1.Equals("")) { f.potenzaF1 = "0"; }
        //                            f.potenzaF2 = ((System.Data.DataRow)item).ItemArray[11].ToString();
        //                            if (f.potenzaF2.Equals("")) { f.potenzaF2 = "0"; }
        //                            f.potenzaF3 = ((System.Data.DataRow)item).ItemArray[12].ToString();
        //                            if (f.potenzaF3.Equals("")) { f.potenzaF3 = "0"; }

        //                            int potenzaF1 = 0;
        //                            int potenzaF2 = 0;
        //                            int potenzaF3 = 0;

        //                            double dPotenza1 = Double.Parse(f.potenzaF1);
        //                            double dPotenza2 = Double.Parse(f.potenzaF2);
        //                            double dPotenza3 = Double.Parse(f.potenzaF3);
        //                            if (dPotenza1 == dPotenza2 && dPotenza1 == dPotenza3)
        //                            {
        //                                f.potenzaMax = dPotenza1 + "";
        //                            }
        //                            else
        //                            {
        //                                double[] potenze = { dPotenza1, dPotenza2, dPotenza3 };
        //                                f.potenzaMax = potenze.Max() + "";
        //                            }

        //                            f.matricolaMisuratore = ((System.Data.DataRow)item).ItemArray[13].ToString();
        //                            if (f.matricolaMisuratore.Equals("")) { f.matricolaMisuratore = "00000000"; }
        //                            else if (f.matricolaMisuratore.Length <= 8)
        //                            {
        //                                int lengthMatricola = 8 - f.matricolaMisuratore.Length;
        //                                for (int x = 0; x < lengthMatricola; x++)
        //                                {
        //                                    f.matricolaMisuratore = "0" + f.matricolaMisuratore;
        //                                }
        //                            }
        //                            else if (f.matricolaMisuratore.Length > 8)
        //                            {
        //                                MessageBox.Show("La Matricola Misuratore deve avere massimo 8 caratteri!!!", "Errori Matricola Misuratore", MessageBoxButton.OK, MessageBoxImage.Error);
        //                                return null;
        //                            }

        //                            f.codiceMisuratore = ((System.Data.DataRow)item).ItemArray[14].ToString();
        //                            if (f.codiceMisuratore.Equals("")) { f.codiceMisuratore = "000000000"; }
        //                            else if (f.codiceMisuratore.Length <= 9)
        //                            {
        //                                int lengthCodMisuratore = 9 - f.codiceMisuratore.Length;
        //                                for (int y = 0; y < lengthCodMisuratore; y++)
        //                                {
        //                                    f.codiceMisuratore = "0" + f.codiceMisuratore;
        //                                }
        //                            }
        //                            else if (f.codiceMisuratore.Length > 9)
        //                            {
        //                                MessageBox.Show("Il Codice Misuratore deve avere massimo 9 caratteri!!!", "Errori Codice Misuratore", MessageBoxButton.OK, MessageBoxImage.Error);
        //                                return null;
        //                            }

        //                            f.provenienza = Costanti.LETTURE_FROM_EXCEL;
        //                            f.colore = Costanti.COLORE_LETTURE_EXCEL;
        //                            f.modifica = true;

        //                            #endregion

        //                            listaMisureExcel.Add(f);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Numero di colonne ERRATO!!!\nUtilizzare il file MASTER scaricato dalla Modale!\nLe colonne devono essere 16.\nAttualmente ne sono: " + dtExcel.Columns.Count, "ERRORE COLONNE", MessageBoxButton.OK, MessageBoxImage.Error);
        //                }
        //            }
        //        }
        //    }

        //    #endregion

        //    return dtExcel;
        //}

        private void LoadData()
        {
            // Creazione di un DataTable con alcune colonne
            DataTable dataTable = new DataTable();

            #region Column DataTable 
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Categories", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Location", typeof(string));
            dataTable.Columns.Add("Threshold", typeof(string));
            dataTable.Columns.Add("Action", typeof(int));
            dataTable.Columns.Add("Deleted", typeof(int));

            // Aggiunta di alcune righe di esempio
            dataTable.Rows.Add(1, "Post-it", 30);
            dataTable.Rows.Add(2, "10", 25);
            dataTable.Rows.Add(3, "Internet Bill", 35);
            dataTable.Rows.Add(4, "Post-it", 35);
            dataTable.Rows.Add(5, "First locker", 35);
            dataTable.Rows.Add(6, "500/-", 35);
            dataTable.Rows.Add(7, "Modify", 35);
            dataTable.Rows.Add(8, "Deleted", 35);
            #endregion

            // Imposta la proprietà ItemsSource della DataGrid
            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void Resetta()
        {
            this.Height = 550; this.Width = 900;
        }

        private void Ridimensiona()
        {
            this.Height = 550; this.Width = 1150;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
