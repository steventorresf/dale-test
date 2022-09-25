import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { VentaService } from 'src/app/services/venta.service';
import { FormVentaComponent } from './form-venta/form-venta.component';

@Component({
  selector: 'app-ventas',
  providers: [VentaService],
  templateUrl: './ventas.component.html',
  styleUrls: ['./ventas.component.scss']
})
export class VentasComponent implements OnInit {

  displayedColumns = ['id', 'fecha', 'cedula', 'nombre', 'valorTotal', 'accion'];
  dataSource = [];

  constructor(
    private _ventaService: VentaService,
    private _dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this._ventaService.getAll().subscribe({
      next: response => {
        console.log('response', response)
        this.dataSource = response;
      },
      error: error => {
        alert(`Error inesperado: ${error}`);
      }
    });
  }

  abrirDialogo(id: number, clienteId: number) {
    const dialogo = this._dialog.open(FormVentaComponent, {
      data: {id: id, clienteId: clienteId}
    });

    dialogo.afterClosed().subscribe(data => {
      if (data) {
        this.getAll();
      }
    });
  }

}
