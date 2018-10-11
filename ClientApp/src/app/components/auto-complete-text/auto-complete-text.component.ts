import { Component, Input, Output, OnInit, SimpleChanges } from '@angular/core';
import { CompleterService, CompleterData } from 'ng2-completer';
import { EventEmitter } from '@angular/core';


@Component({
  selector: 'app-auto-complete-text',
  template : `<ng2-completer [(ngModel)]="searchStr" (change)="itemIsSelected()" [datasource]="valuesList" [minSearchLength]="0" >
  </ng2-completer>`,

  styleUrls: ['./auto-complete-text.component.css']
})

export class AutoCompleteTextComponent implements OnInit {

  private keysList: any[];
  private valuesList: any[];

  @Input() keyValuePairs: any;

  // Bunu input olarak tanımadım. Output olarak searchKeyChange'de dönüyorum. searchKey ve searchKeyChange
  // isimlendirmeleri önemli imiş. Angular buradan anlıyormuş.
  // https://stackoverflow.com/questions/35327929/angular-2-ngmodel-in-child-component-updates-parent-component-property
  @Input() searchKey: string;

  @Output() itemSelectedEvent: EventEmitter<any> = new EventEmitter();
  @Output() searchKeyChange: EventEmitter<any> = new EventEmitter();

  protected completerService: CompleterService;
  protected dataService: CompleterData;

  private searchStr;

  constructor(private c: CompleterService) {
    this.completerService = c;

    // this.dataService = c.remote(this.sourceList, 'name' )

  }

  ngOnInit(): void {
    this.keysList = Object.keys(this.keyValuePairs);
    this.valuesList = Object.values(this.keyValuePairs);
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnChanges(changes: any): void {
    this.keysList = Object.keys(this.keyValuePairs);
    this.valuesList = Object.values(this.keyValuePairs);
  }



  itemIsSelected() {
    const selectedKey = Object.keys(this.keyValuePairs).find(key => this.keyValuePairs[key] === this.searchStr);
    this.itemSelectedEvent.emit({key : selectedKey, value: this.searchStr});
    this.searchKey = selectedKey;
    this.searchKeyChange.emit(this.searchKey); // Bunu modellerimde direkt kullanmak için kvp'de olmasıa rağmen bir daha parent'a yolluyorum
  }

}
