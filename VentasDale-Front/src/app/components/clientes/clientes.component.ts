import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ClienteService } from 'src/app/services/cliente.service';
import { FormClienteComponent } from './form-cliente/form-cliente.component';

@Component({
  selector: 'app-clientes',
  providers: [ClienteService],
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {

  displayedColumns = ['cedula', 'nombre', 'apellido', 'telefono', 'accion'];
  dataSource = [];

  constructor(
    private _clienteService: ClienteService,
    private _dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this._clienteService.getAll().subscribe({
      next: response => {
        console.log('response', response)
        this.dataSource = response;
      },
      error: error => {
        alert(`Error inesperado: ${error}`);
      }
    });
  }

  abrirDialogo(id: number) {
    const dialogo = this._dialog.open(FormClienteComponent, {
      data: id
    });

    dialogo.afterClosed().subscribe(data => {
      if (data) {
        this.getAll();
      }
    });    
  }

}
