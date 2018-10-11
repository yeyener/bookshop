import { CommunicatorService } from './../../services/communicator.service';
import { Router, ActivatedRoute } from '@angular/router';
import { BookInstService } from './../../services/book-inst.service';
import { WriterService } from './../../services/writer.service';
import { Component, OnInit } from '@angular/core';
import { BookdefService } from '../../services/bookdef.service';
import { MiscService } from '../../services/misc.service';
import { BookInstance } from '../../pocos/bookInstance';

@Component({
  selector: 'app-book-inst',
  templateUrl: './book-inst.component.html',
  styleUrls: ['./book-inst.component.css']
})
export class BookInstComponent implements OnInit {

  writersAsKvps: any = [];
  bookDefsAsKvps: any = [];
  publishersAsKvps: any = [];
  languagesAsKvps: any = [];
  translatorsAsKvps: any = [];

  writersLoaded: Promise<boolean>;
  bookDefsLoaded: Promise<boolean>;
  publishersLoaded: Promise<boolean>;
  languagesLoaded: Promise<boolean>;
  translatorsLoaded: Promise<boolean>;

  selectedWriterId: any;

  newBookInstance: any;
  // newBookInstance: BookInstance; //@yey TODO
  private edit: boolean;

  constructor(private writerService: WriterService,
    private bookdefService: BookdefService,
    private miscService: MiscService,
    private bookInstService: BookInstService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private communicator: CommunicatorService
      ) { }

  ngOnInit() {
      // if (this.activatedRoute.snapshot.params['ref'] === 'list') {
      //   this.edit = true;
      //   this.newBookInstance = this.communicator.pop();
      // } else {
        this.newBookInstance = { definitionId: -1, publisherName: -1, languageName: -1, tranlatorId: -1, price: 0, };
      // }

      this.writerService.getAllNamesAndIds().subscribe(a => {
      this.writersAsKvps = a;
      this.writersLoaded = Promise.resolve(true);
    });

    this.miscService.getLanguages().subscribe(a => {this.languagesAsKvps = a; this.languagesLoaded = Promise.resolve(true); });
    this.miscService.getTranslators().subscribe(a => { this.translatorsAsKvps = a; this.translatorsLoaded = Promise.resolve(true); });
    this.miscService.getPublishers().subscribe(a => { this.publishersAsKvps = a; this.publishersLoaded = Promise.resolve(true); });
  }

  onSelectWriter(selectedWriter: any) {
    this.selectedWriterId = selectedWriter.key;
    this.bookdefService.getWritersBookDefsAsKvps(this.selectedWriterId).subscribe(a => {
      this.bookDefsAsKvps = a;
      this.bookDefsLoaded = Promise.resolve(true);
    });
  }

  onSelectBookDef(selectedBookDef: any) {
      this.newBookInstance.definitionId = selectedBookDef.key;
  }

  createBookInstance() {
     this.bookInstService.create(this.newBookInstance).subscribe(a => alert(a));
  }

  editDetails() {
    this.router.navigate(['/bookinst-form/']);
  }

}
