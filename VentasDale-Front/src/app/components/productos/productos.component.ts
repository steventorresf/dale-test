import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductoService } from 'src/app/services/producto.service';
import { FormProductoComponent } from './form-producto/form-producto.component';

@Component({
  selector: 'app-productos',
  providers: [ProductoService],
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss']
})
export class ProductosComponent implements OnInit {

  displayedColumns = ['nombre', 'valorUnitario', 'accion'];
  dataSource = [];

  constructor(
    private _productoService: ProductoService,
    private _dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this._productoService.getAll().subscribe({
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
    const dialogo = this._dialog.open(FormProductoComponent, {
      data: id
    });

    dialogo.afterClosed().subscribe(data => {
      if (data) {
        this.getAll();
      }
    });
  }

}
