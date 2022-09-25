import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { ClienteService } from 'src/app/services/cliente.service';
import { SnackBarService } from 'src/app/services/snackBar.service';
import { VentaService } from 'src/app/services/venta.service';
import { FormProductoVentaComponent } from '../form-producto-venta/form-producto-venta.component';

@Component({
  selector: 'app-form-venta',
  providers: [ClienteService, VentaService],
  templateUrl: './form-venta.component.html',
  styleUrls: ['./form-venta.component.scss']
})
export class FormVentaComponent implements OnInit {
  
  displayedColumns = ['nombre', 'cantidad', 'valorUnitario', 'valorTotal', 'accion'];
  dataSource: any = [];
  i = 0;

  formEdit = true;
  mostrar = {
    busquedaCedula: true,
    botonAgregar: true,
    botonQuitar: true
  }

  myForm: FormGroup = this._formBuilder.group({
    cedulaBusqueda: [null],
    fecha: [new Date(), Validators.required],
    clienteId: [null, Validators.required],
    cedula: [{value: null, disabled: true}, Validators.required],
    nombre: [{value: null, disabled: true}, Validators.required],
    apellido: [{value: null, disabled: true}, Validators.required],
    telefono: {value: null, disabled: true}
  });

  constructor(
    private _snackBar: SnackBarService,
    private _clienteService: ClienteService,
    private _ventaService: VentaService,
    private _formBuilder: FormBuilder,
    private _dialog: MatDialog,
    public _dialogRef: MatDialogRef<FormVentaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  @ViewChild(MatTable) table!: MatTable<any>;

  ngOnInit(): void {
    if(this.data.id > 0){
      this.myForm.get('fecha')?.disable();
      this.formEdit = false;
      this.mostrar.busquedaCedula = false;
      this.mostrar.botonAgregar = false;
      this.mostrar.botonQuitar = false;
      this.getVentaById();
    }
    else if(this.data.clienteId > 0){
      this.mostrar.busquedaCedula = false;
      this.getClienteById();
    }
  }

  getVentaById(){
    this._ventaService.getById(this.data.id).subscribe({
      next: response => {
        this.myForm.patchValue({
          fecha: response.fechaVenta,
          clienteId: response.clienteId,
          cedula: response.cedula,
          nombre: response.nombre,
          apellido: response.apellido,
          telefono: response.telefono
        });

        response.ventasDetalle.forEach((item: any) => {
          this.dataSource.push({
            nombre: item.nombreProducto,
            cantidad: item.cantidad,
            valorUnitario: item.valorUnitario,
            valorTotal: item.valorTotal
          })
        });

        this.table.renderRows();
      }
    })
  }

  getClienteById(){
    this._clienteService.getById(this.data.clienteId).subscribe({
      next: response => {
        this.myForm.patchValue({
          clienteId: response.clienteId,
          cedula: response.cedula,
          nombre: response.nombre,
          apellido: response.apellido,
          telefono: response.telefono
        });
      }
    })
  }

  getClienteByCedula(){
    this._clienteService.getByCedula(this.myForm.get('cedulaBusqueda')?.value).subscribe({
      next: response => {
        this.myForm.patchValue({
          clienteId: response.clienteId,
          cedula: response.cedula,
          nombre: response.nombre,
          apellido: response.apellido,
          telefono: response.telefono
        });

        if(response.clienteId == 0){
          this._snackBar.showInfo('No existe un cliente con la cédula: ' + this.myForm.get('cedulaBusqueda')?.value);
        }
      }
    })
  }

  abrirDialogo(){
    const dialogo = this._dialog.open(FormProductoVentaComponent, {});

    dialogo.afterClosed().subscribe(data => {
      if (data) {
        this.dataSource.push({
          id: ++this.i,
          ...data,
          valorTotal: data.valorUnitario * data.cantidad
        });
        this.table.renderRows();
      }
    });
  }

  quitarProducto(id: number){
    this.dataSource = this.dataSource.filter(function(item: any){
      return item.id != id;
    })
  }

  cancelar(){
    this._dialogRef.close();
  }

  guardarFacturaVenta(){
    const ventaDetalle: any = [];
    this.dataSource.forEach((item: any) => {
      ventaDetalle.push({
        ventaDetalleId: 0,
        ventaId: 0,
        productoId: item.productoId,
        Cantidad: item.cantidad,
        ValorUnitario: item.valorUnitario
      });
    });

    const venta = {
      ventaId: 0,
      clienteId: this.myForm.get('clienteId')?.value,
      fecha: this.myForm.get('fecha')?.value,
      ventasDetalle: ventaDetalle
    };

    this._ventaService.Save(venta).subscribe({
      next: response => {
        this._dialogRef.close(true);
        this._snackBar.showSuccess('La factura de venta sido generada correctamente!!');
      }
    })
  }

}
