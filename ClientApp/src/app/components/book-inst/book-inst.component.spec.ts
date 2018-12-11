import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookInstComponent } from './book-inst.component';
import { WriterService } from '../../services/writer.service';
import { BookdefService } from '../../services/bookdef.service';
import { BookInstService } from '../../services/book-inst.service';
import { MiscService } from '../../services/misc.service';
import { CommunicatorService } from '../../services/communicator.service';
import { BookErrorHandler } from '../../handlers/bookErrorHandler';
import { PhotoService } from '../../services/photo.service';
import { AuthService } from '../../services/auth.service';
import { RouteProtectorService } from '../../services/route-protector.service';
import { ModalCheckBoxComponent } from '../modal-check-box/modal-check-box.component';
import { FrontPageService } from '../../services/front-page.service';
import { NavBarService } from '../../services/nav-bar.service';
import { JwtHelper } from 'angular2-jwt';
import { JsonTsConverterService } from '../../json-ts-converter.service';

describe('BookInstComponent', () => {
  let component: BookInstComponent;
  let fixture: ComponentFixture<BookInstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookInstComponent ],
      imports  : [],
      providers : [WriterService, BookdefService, BookInstService, MiscService, CommunicatorService, BookErrorHandler, PhotoService,
         AuthService, RouteProtectorService, ModalCheckBoxComponent, FrontPageService, NavBarService, JwtHelper, JsonTsConverterService]
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
