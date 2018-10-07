import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookdefFormComponent } from './bookdef-form.component';

describe('BookdefFormComponent', () => {
  let component: BookdefFormComponent;
  let fixture: ComponentFixture<BookdefFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookdefFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookdefFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
