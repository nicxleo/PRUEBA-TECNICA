using System;
using SegurosPrueba.Tools;
using SegurosPrueba.DataBase;
using System.Web.UI.WebControls;
using System.Linq;

namespace SegurosPrueba
{
    public partial class Compania : System.Web.UI.Page
    {
        private void LimpiarCompania()
        {
            PnlListas.Visible = true;
            PnlNuevaCompania.Visible = false;
            PnlNuevoProducto.Visible = false;
            TxtNombreCompania.Text = string.Empty;
        }

        private void LimpiarProducto()
        {
            PnlListas.Visible = true;
            PnlNuevaCompania.Visible = false;
            PnlNuevoProducto.Visible = false;
            TxtNombreProducto.Text = string.Empty;
            TxtPrima.Text = string.Empty;
            TxtCobertura.Text = string.Empty;
            TxtAsistencia.Text = string.Empty;
            CmbCompania.SelectedIndex = -1;
            HddIdProducto.Value = string.Empty;
        }

        private void LlenarListaCompania()
        {
            var db = new SegurosPruebaEntities();
            try
            {
                LstCompanias.Items.Clear();
                CmbCompania.Items.Clear();
                foreach (var item in db.tbl_Compania)
                {
                    LstCompanias.Items.Add(new ListItem(item.nombre_compania, item.id_compania.ToString()));
                    CmbCompania.Items.Add(new ListItem(item.nombre_compania, item.id_compania.ToString()));
                }
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        private void LlenarListaProducto(string pIdCompania)
        {
            var db = new SegurosPruebaEntities();
            try
            {
                LstProductos.Items.Clear();
                foreach (var item in db.tbl_Producto.Where(x => x.id_compania.ToString().Equals(pIdCompania)))
                {
                    LstProductos.Items.Add(new ListItem(item.nombre_producto, item.id_producto.ToString()));
                }
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarListaCompania();
            }
        }

        protected void BtnNuevaCompania_Click(object sender, EventArgs e)
        {
            PnlListas.Visible = false;
            PnlNuevaCompania.Visible = true;
        }

        protected void BtnGuardarCompania_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreCompania.Text))
            {
                Util.ShowMessage("El campo no puede estar en blanco.", this);
                return;
            }
            var db = new SegurosPruebaEntities();
            try
            {
                db.tbl_Compania.Add(new tbl_Compania
                {
                    nombre_compania = TxtNombreCompania.Text
                });
                db.SaveChanges();
                LimpiarCompania();
                LlenarListaCompania();
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        protected void BtnAtrasCompania_Click(object sender, EventArgs e)
        {
            LimpiarCompania();
        }

        protected void LstCompanias_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarListaProducto(LstCompanias.SelectedValue);
        }

        protected void BtnNuevoProducto_Click(object sender, EventArgs e)
        {
            PnlListas.Visible = false;
            PnlNuevoProducto.Visible = true;
        }

        protected void BtnAtrasProducto_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }

        protected void BtnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreProducto.Text))
            {
                Util.ShowMessage("El campo no puede estar en blanco.", this);
                return;
            }
            var db = new SegurosPruebaEntities();
            try
            {
                if (string.IsNullOrEmpty(HddIdProducto.Value))
                {
                    db.tbl_Producto.Add(new tbl_Producto
                    {
                        nombre_producto = TxtNombreProducto.Text,
                        prima = Convert.ToDecimal(TxtPrima.Text),
                        cobertura = TxtCobertura.Text,
                        asistencia = TxtAsistencia.Text,
                        id_compania = Convert.ToInt32(CmbCompania.SelectedValue)
                    });
                }
                else
                {
                    var vProducto = db.tbl_Producto.FirstOrDefault(x => x.id_producto.ToString().Equals(HddIdProducto.Value));
                    vProducto.nombre_producto = TxtNombreProducto.Text;
                    vProducto.prima = Convert.ToDecimal(TxtPrima.Text);
                    vProducto.cobertura = TxtCobertura.Text;
                    vProducto.asistencia = TxtAsistencia.Text;
                    vProducto.id_compania = Convert.ToInt32(CmbCompania.SelectedValue);
                }
                db.SaveChanges();
                LimpiarProducto();
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        protected void BtnEditarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LstProductos.SelectedValue))
            {
                Util.ShowMessage("no se ha seleccionado ningún producto.", this);
                return;
            }

            var db = new SegurosPruebaEntities();
            try
            {
                var vProducto = db.tbl_Producto.FirstOrDefault(x => x.id_producto.ToString().Equals(LstProductos.SelectedValue));
                HddIdProducto.Value = vProducto.id_producto.ToString();
                TxtNombreProducto.Text = vProducto.nombre_producto;
                TxtPrima.Text = vProducto.prima.ToString();
                TxtCobertura.Text = vProducto.cobertura;
                TxtAsistencia.Text = vProducto.asistencia;
                CmbCompania.SelectedValue = vProducto.id_compania.ToString();

                PnlListas.Visible = false;
                PnlNuevoProducto.Visible = true;
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }
    }
}