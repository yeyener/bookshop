import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AutoCompleteTextComponent } from './auto-complete-text.component';

describe('AutoCompleteTextComponent', () => {
  let component: AutoCompleteTextComponent;
  let fixture: ComponentFixture<AutoCompleteTextComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutoCompleteTextComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutoCompleteTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
