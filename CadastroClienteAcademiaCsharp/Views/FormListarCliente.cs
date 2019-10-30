﻿using CadastroClienteAcademiaCsharp.Services;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CadastroClienteAcademiaCsharp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClienteAcademiaCsharp
{
    public partial class FormListarCliente : Form
    {
        private ClienteService _clienteService;

        public FormListarCliente()
        {
            InitializeComponent();
            _clienteService = new ClienteService();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            var formularioCliente = new FormularioCliente(this);
            formularioCliente.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var formularioCliente = new FormularioCliente(this, dgvCliente.CurrentRow.Cells["Id"].Value.ToString());
            formularioCliente.Show();
        }

        private void FormListarCliente_Load(object sender, EventArgs e)
        {
            SetDataSource(_clienteService.GetClientes());
        }

        private void SetDataSource(IEnumerable<Cliente> dados)
        {
            var data = dados.Select(x => new
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nome = x.Nome,
                Telefone = x.Telefone,
                Cidade = x.Cidade?.Nome ?? string.Empty
            }).ToList();

            dgvCliente.DataSource = data;
            dgvCliente.Columns[0].Visible = false;
        }

        public void btnBusca_Click(object sender, EventArgs e)
        {
            SetDataSource(_clienteService.GetClientes(txtBusca.Text));
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnBusca_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBusca.Text = "";
            txtBusca.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedCells.Count > 0)
            {
                var resposta = MessageBox.Show("Deseja excluir o cliente selecionado?", "Excluir", MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    _clienteService.DeleteCliente(dgvCliente.CurrentRow.Cells["Id"].Value.ToString());
                    btnBusca_Click(sender, e);
                }
            }
        }
    }
}