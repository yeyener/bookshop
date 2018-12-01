import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalCheckBoxComponent } from './modal-check-box.component';

describe('ModalCheckBoxComponent', () => {
  let component: ModalCheckBoxComponent;
  let fixture: ComponentFixture<ModalCheckBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalCheckBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalCheckBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
