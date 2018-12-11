import { ErrorHandler } from '@angular/core';
import { PhotoService } from './../../services/photo.service';
import { CommunicatorService } from './../../services/communicator.service';
import { Router, ActivatedRoute } from '@angular/router';
import { BookInstService } from './../../services/book-inst.service';
import { WriterService } from './../../services/writer.service';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { BookdefService } from '../../services/bookdef.service';
import { MiscService } from '../../services/misc.service';
import { BookInstance } from '../../pocos/bookInstance';
import { BookErrorHandler } from '../../handlers/bookErrorHandler';

@Component({
  selector: 'app-book-inst',
  templateUrl: './book-inst.component.html',
  styleUrls: ['./book-inst.component.css']
})
export class BookInstComponent implements OnInit {

  @ViewChild('fileInputEkran') fileInput: ElementRef;
  writersAsKvps: any = [];
  bookDefsAsKvps: any = [];
  publishersAsKvps: any = [];
  languagesAsKvps: any = [];
  translatorsAsKvps: any = [];
  photos: any = [];

  writersLoaded: Promise<boolean>;
  bookDefsLoaded: Promise<boolean>;
  publishersLoaded: Promise<boolean>;
  languagesLoaded: Promise<boolean>;
  translatorsLoaded: Promise<boolean>;

  gotEditInfo: Promise<boolean>;

  selectedWriterId: any;
  createMode: boolean;

  newBookInstance: BookInstance;
  constructor(private writerService: WriterService, private bookdefService: BookdefService, private miscService: MiscService,
    private bookInstService: BookInstService, private router: Router, private activatedRoute: ActivatedRoute,
    private communicator: CommunicatorService, private errHandler: BookErrorHandler, private photoService: PhotoService
      ) { }

  ngOnInit() {
      if (this.activatedRoute.snapshot.params['ref'] === 'list') {
        const redirectObject = this.communicator.pop<BookInstance>();
        if (redirectObject !== null && redirectObject !== void 0  && redirectObject.id > 0 ) {
          this.newBookInstance = redirectObject;
          this.gotEditInfo = Promise.resolve(true);
          this.photoService.getPhotos(this.newBookInstance.id).subscribe(
            a => {this.photos = a; },
            err => {this.errHandler.handleError(err); }
          );
        } else {
          this.createModeInit();
        }
      } else {
        this.createModeInit();
    }

    this.miscService.getLanguages().subscribe(a => {this.languagesAsKvps = a; this.languagesLoaded = Promise.resolve(true); });
    this.miscService.getTranslators().subscribe(a => { this.translatorsAsKvps = a; this.translatorsLoaded = Promise.resolve(true); });
    this.miscService.getPublishers().subscribe(a => { this.publishersAsKvps = a; this.publishersLoaded = Promise.resolve(true); });
  }

  private createModeInit() {
      this.newBookInstance = BookInstance.createEmpty();
      this.createMode = true;
      this.writerService.getAllNamesAndIds().subscribe(a => {
        this.writersAsKvps = a;
        this.writersLoaded = Promise.resolve(true);
      }, err => {this.errHandler.handleError(err); }
      );
  }

  onSelectWriter(selectedWriter: any) {
    this.selectedWriterId = selectedWriter.key;
    this.bookdefService.getWritersBookDefsAsKvps(this.selectedWriterId).subscribe(a => {
      this.bookDefsAsKvps = a;
      this.bookDefsLoaded = Promise.resolve(true);
    });
  }

  onSelectBookDef(selectedBookDef: any) {this.newBookInstance.definitionId = selectedBookDef.key; }

  onSelectPublisher(p: any) {this.newBookInstance.publisherId = p.key; }

  onSelectLanguage(l: any) {this.newBookInstance.languageId = l.key; }

  onSelectTranslator(t: any) {this.newBookInstance.translatorId = t.key; }

  createBookInstance() {
     this.bookInstService.create(this.newBookInstance).
     subscribe(a => {alert(a); this.router.navigate(['booklist-form']); },
     err => {this.errHandler.handleError(err); }
     );
  }

  editBookInstance() {
    this.bookInstService.edit(this.newBookInstance).
    subscribe(a => alert(a),
    err => {this.errHandler.handleError(err); }
    );
  }

  deleteBookInstance() {
    this.bookInstService.delete(this.newBookInstance.id).
    subscribe(a => { alert('Book instance deleted'); this.router.navigate(['booklist-form']); } ,
    err => {this.errHandler.handleError(err); }
    );
  }

  uploadPhoto() {
    const nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    const file = nativeElement.files[0];
    nativeElement.value = ''; // input field'ı temizlemek için

    this.photoService.upload(this.newBookInstance.id, file).subscribe( photo => this.photos.push(photo) );
  }

  getPhotos() {
    this.photoService.getPhotos(this.newBookInstance.id);
  }

}
