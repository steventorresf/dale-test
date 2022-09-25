import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClienteService } from 'src/app/services/cliente.service';
import { SnackBarService } from 'src/app/services/snackBar.service';

@Component({
  selector: 'app-form-cliente',
  providers: [ClienteService],
  templateUrl: './form-cliente.component.html',
  styleUrls: ['./form-cliente.component.scss']
})
export class FormClienteComponent implements OnInit {

  myForm: FormGroup = this._formBuilder.group({
    cedula: [null, [Validators.required]],
    nombre: [null, [Validators.required]],
    apellido: [null, [Validators.required]],
    telefono: [null],
  });

  constructor(
    private _snackBar: SnackBarService,
    private _clienteService : ClienteService,
    private _formBuilder: FormBuilder,
    public _dialogRef: MatDialogRef<FormClienteComponent>,
    @Inject(MAT_DIALOG_DATA) public id: number
  ) { }

  ngOnInit(): void {
    if(this.id > 0){
      this.myForm.get('cedula')?.disable();
      this.getClienteById();
    }
  }



  getClienteById(){
    this._clienteService.getById(this.id).subscribe({
      next: response => {
        this.myForm.patchValue({
          cedula: response.cedula,
          nombre: response.nombre,
          apellido: response.apellido,
          telefono: response.telefono,
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
      clienteId: this.id,
      cedula: this.myForm.get('cedula')?.value,
      nombre: this.myForm.get('nombre')?.value,
      apellido: this.myForm.get('apellido')?.value,
      telefono: this.myForm.get('telefono')?.value
    };

    let response = this.id == 0 ? this._clienteService.Save(data) : this._clienteService.Update(data);
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
