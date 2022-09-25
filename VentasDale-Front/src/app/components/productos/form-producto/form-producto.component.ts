import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductoService } from 'src/app/services/producto.service';
import { SnackBarService } from 'src/app/services/snackBar.service';

@Component({
  selector: 'app-form-producto',
  providers: [ProductoService],
  templateUrl: './form-producto.component.html',
  styleUrls: ['./form-producto.component.scss']
})
export class FormProductoComponent implements OnInit {

  myForm: FormGroup = this._formBuilder.group({
    nombre: [null, [Validators.required]],
    valorUnitario: [null, [Validators.required]]
  });

  constructor(
    private _snackBar: SnackBarService,
    private _productoService : ProductoService,
    private _formBuilder: FormBuilder,
    public _dialogRef: MatDialogRef<FormProductoComponent>,
    @Inject(MAT_DIALOG_DATA) public id: number
  ) { }

  ngOnInit(): void {
    if(this.id > 0){
      this.getClienteById();
    }
  }



  getClienteById(){
    this._productoService.getById(this.id).subscribe({
      next: response => {
        this.myForm.patchValue({
          nombre: response.nombre,
          valorUnitario: response.valorUnitario
        });
      },
      error: error => {
        
      }
    })
  }

  cancelar() {
    this._dialogRef.close(false);
  }

  guardar(){
    const data = {
      productoId: this.id,
      nombre: this.myForm.get('nombre')?.value,
      valorUnitario: this.myForm.get('valorUnitario')?.value
    };

    let response = this.id == 0 ? this._productoService.Save(data) : this._productoService.Update(data);
    response.subscribe({
      next: response => {
        this._dialogRef.close(true);
        this._snackBar.showSuccess('Los datos han sido guardados correctamente!!');
      },
      error: error => {

      }
    });
  }

}
