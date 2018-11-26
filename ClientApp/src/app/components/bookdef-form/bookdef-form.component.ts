import { MiscService } from './../../services/misc.service';
import { WriterService } from './../../services/writer.service';
import { Component, OnInit } from '@angular/core';
import { BookdefService } from '../../services/bookdef.service';
import { Router } from '@angular/router';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'app-bookdef-form',
  templateUrl: './bookdef-form.component.html',
  styleUrls: ['./bookdef-form.component.css']
})
export class BookdefFormComponent implements OnInit {

  allGenres: any = [];

  writersAsKvps: any = [];

  writersLoaded: Promise<boolean>;
  writersBookDefsLoaded: Promise<boolean>;

  writersBookDefs: any = [];

  newBookDef: any = {};
  selectedWriterTxt: string;

  selectedWriterId: any;

  constructor(private writerService: WriterService, private bookDefService: BookdefService, private router: Router,
    private  ngxSmartModalService: NgxSmartModalService, private miscService: MiscService) {
   }

  ngOnInit() {
      this.writerService.getAllNamesAndIds().subscribe(a => {this.writersAsKvps = a;
        this.writersLoaded = Promise.resolve(true);
        });

      this.miscService.getGenres().subscribe(a => {this.allGenres = a; });
  }

    onSelectWriter(selectedWriter: any) {
      this.selectedWriterId = selectedWriter.key;
      this.selectedWriterTxt = selectedWriter.value;
      this.newBookDef.writerId = this.selectedWriterId;
      this.populateBookDefs(this.selectedWriterId);

    }

    goToWriters() {
      this.router.navigate(['/writer-form']);
    }

    updateBookDef(bookDef) {
        this.bookDefService.updateBookDef(bookDef).subscribe(a => {this.populateBookDefs(this.selectedWriterId); });
    }

    deleteBookDef(bookDef) {
      this.bookDefService.deleteBookDef(bookDef).subscribe(a => this.populateBookDefs(this.selectedWriterId),
      err => alert(err.message)
      );
    }

    createBookDef(bookDef) {
      this.bookDefService.createBookDef(bookDef).subscribe(a => this.populateBookDefs(this.selectedWriterId));
    }

    populateBookDefs(selectedWriterKey) {
      this.bookDefService.getWritersBookDefs(selectedWriterKey).subscribe(a => {
        this.writersBookDefs = a;
        this.writersBookDefsLoaded = Promise.resolve(true);
        this.newBookDef = {writerId : this.selectedWriterId };

      });
    }

    showGenres() {
      alert(this.allGenres.length);
      this.ngxSmartModalService.getModal('genresModal').open();
    }

}
