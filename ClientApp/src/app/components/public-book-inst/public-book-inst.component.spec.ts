import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicBookInstComponent } from './public-book-inst.component';

describe('PublicBookInstComponent', () => {
  let component: PublicBookInstComponent;
  let fixture: ComponentFixture<PublicBookInstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PublicBookInstComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublicBookInstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
