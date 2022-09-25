import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-form-producto-venta',
  providers: [ProductoService],
  templateUrl: './form-producto-venta.component.html',
  styleUrls: ['./form-producto-venta.component.scss']
})
export class FormProductoVentaComponent implements OnInit {

  listProductos: any = [];
  myForm: FormGroup = this._formBuilder.group({
    producto: [null, Validators.required],    
    cantidad: [null, Validators.required],
    valorUnitario: [null, Validators.required]
  });

  constructor(
    private _productoService: ProductoService,
    private _formBuilder: FormBuilder,
    public _dialogRef: MatDialogRef<FormProductoVentaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this._productoService.getAll().subscribe({
      next: response => {
        this.listProductos = response;
      },
      error: error => {
        alert(`Error inesperado: ${error}`);
      }
    });
  }

  changeProducto(){
    const producto = this.myForm.get('producto')?.value;
    if(producto){
      this.myForm.get('cantidad')?.setValue(1);
      this.myForm.get('valorUnitario')?.setValue(producto.valorUnitario);
    }
    else{
      this.myForm.get('cantidad')?.setValue(null);
      this.myForm.get('valorUnitario')?.setValue(null);
    }
  }

  agregar(){
    let data = {
      productoId: this.myForm.get('producto')?.value.productoId,
      nombre: this.myForm.get('producto')?.value.nombre,
      cantidad: this.myForm.get('cantidad')?.value,
      valorUnitario: this.myForm.get('valorUnitario')?.value
    };

    this._dialogRef.close(data);
  }

  cancelar(){
    this._dialogRef.close();
  }

}
