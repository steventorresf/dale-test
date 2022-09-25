import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormProductoVentaComponent } from './form-producto-venta.component';

describe('FormProductoVentaComponent', () => {
  let component: FormProductoVentaComponent;
  let fixture: ComponentFixture<FormProductoVentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormProductoVentaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormProductoVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
