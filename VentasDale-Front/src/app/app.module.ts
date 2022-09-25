import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {MaterialModule} from './material.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';
import {NgxMatSelectSearchModule} from 'ngx-mat-select-search';
import {HttpClientModule} from '@angular/common/http';
//import {MatFormFieldModule} from '@angular/material/form-field';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ClientesComponent} from './components/clientes/clientes.component';
import {ProductosComponent} from './components/productos/productos.component';
import {FormClienteComponent} from './components/clientes/form-cliente/form-cliente.component';
import {FormProductoComponent} from './components/productos/form-producto/form-producto.component';
import { VentasComponent } from './components/ventas/ventas.component';
import { FormVentaComponent } from './components/ventas/form-venta/form-venta.component';
import { FormProductoVentaComponent } from './components/ventas/form-producto-venta/form-producto-venta.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    ProductosComponent,
    FormClienteComponent,
    FormProductoComponent,
    VentasComponent,
    FormVentaComponent,
    FormProductoVentaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    MatNativeDateModule,
    NgxMatSelectSearchModule,
    //MatFormFieldModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
