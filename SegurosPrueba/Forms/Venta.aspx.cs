using SegurosPrueba.DataBase;
using SegurosPrueba.Tools;
using System;
using System.Web.UI.WebControls;

namespace SegurosPrueba.Forms
{
    public partial class Venta : System.Web.UI.Page
    {
        private void LimpiarAsesor()
        {
            PnlVenta.Visible = true;
            PnlNuevoAsesor.Visible = false;
            PnlNuevoCliente.Visible = false;
            TxtNombreAsesor.Text = string.Empty;
        }

        private void LimpiarCliente()
        {
            PnlVenta.Visible = true;
            PnlNuevoAsesor.Visible = false;
            PnlNuevoCliente.Visible = false;
            TxtNombreCliente.Text = string.Empty;
            TxtApellidoCliente.Text = string.Empty;
            TxtCedulaCliente.Text = string.Empty;
            TxtTelefonoCliente.Text = string.Empty;
            TxtDireccionCliente.Text = string.Empty;
        }

        private void LlenarListaProducto()
        {
            var db = new SegurosPruebaEntities();
            try
            {
                CmbProducto.Items.Clear();
                foreach (var item in db.tbl_Producto)
                {
                    CmbProducto.Items.Add(new ListItem(item.nombre_producto, item.id_producto.ToString()));
                }
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        private void LlenarListaAsesor()
        {
            var db = new SegurosPruebaEntities();
            try
            {
                CmbAsesor.Items.Clear();
                foreach (var item in db.tbl_Asesor)
                {
                    CmbAsesor.Items.Add(new ListItem(item.nombre_asesor, item.id_asesor.ToString()));
                }
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        private void LlenarListaCliente()
        {
            var db = new SegurosPruebaEntities();
            try
            {
                CmbCliente.Items.Clear();
                foreach (var item in db.tbl_Cliente)
                {
                    CmbCliente.Items.Add(new ListItem(item.nombre_cliente + " " + item.apellido_cliente, item.id_cliente.ToString()));
                }
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        private void LlenarListaVenta()
        {
            var db = new SegurosPruebaEntities();
            try
            {
                LstVentas.Items.Clear();
                foreach (var item in db.tbl_Venta)
                {
                    LstVentas.Items.Add(new ListItem(item.fecha.ToString("F"), item.id_venta.ToString()));
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
                LlenarListaProducto();
                LlenarListaAsesor();
                LlenarListaCliente();
                LlenarListaVenta();
            }
        }

        protected void BtnNuevoAsesor_Click(object sender, EventArgs e)
        {
            PnlVenta.Visible = false;
            PnlNuevoAsesor.Visible = true;
        }

        protected void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            PnlVenta.Visible = false;
            PnlNuevoCliente.Visible = true;
        }

        protected void BtnGuardarAsesor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreAsesor.Text))
            {
                Util.ShowMessage("El campo no puede estar en blanco.", this);
                return;
            }
            var db = new SegurosPruebaEntities();
            try
            {
                db.tbl_Asesor.Add(new tbl_Asesor
                {
                    nombre_asesor = TxtNombreAsesor.Text
                });
                db.SaveChanges();
                LimpiarAsesor();
                LlenarListaAsesor();
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        protected void BtnAtrasAsesor_Click(object sender, EventArgs e)
        {
            LimpiarAsesor();
        }

        protected void BtnGuardarCliente_Click(object sender, EventArgs e)
        {
            var db = new SegurosPruebaEntities();
            try
            {
                db.tbl_Cliente.Add(new tbl_Cliente
                {
                    nombre_cliente = TxtNombreCliente.Text,
                    apellido_cliente = TxtApellidoCliente.Text,
                    cedula_cliente = TxtCedulaCliente.Text,
                    telefono_cliente = TxtTelefonoCliente.Text,
                    direccion_cliente = TxtDireccionCliente.Text
                });
                db.SaveChanges();
                LimpiarCliente();
                LlenarListaCliente();
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }

        protected void BtnAtrasCliente_Click(object sender, EventArgs e)
        {
            LimpiarCliente();
        }

        protected void BtnVenta_Click(object sender, EventArgs e)
        {
            var db = new SegurosPruebaEntities();
            try
            {
                db.tbl_Venta.Add(new tbl_Venta
                {
                    id_asesor = Convert.ToInt32(CmbAsesor.SelectedValue),
                    id_cliente = Convert.ToInt32(CmbCliente.SelectedValue),
                    id_producto = Convert.ToInt32(CmbProducto.SelectedValue),
                    fecha = DateTime.Now
                });
                db.SaveChanges();
                LlenarListaVenta();
            }
            catch (Exception ex)
            {
                Util.ShowMessage(ex.Message, this);
            }
            db.Dispose();
        }
    }
}