import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookInstComponent } from './book-inst.component';

describe('BookInstComponent', () => {
  let component: BookInstComponent;
  let fixture: ComponentFixture<BookInstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookInstComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookInstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
