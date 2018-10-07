import { Component, Input, Output, OnInit } from '@angular/core';
import { CompleterService, CompleterData } from 'ng2-completer';
import { EventEmitter } from '@angular/core';



@Component({
  selector: 'app-auto-complete-text',
  template : `<ng2-completer [(ngModel)]="searchStr" (change)="itemIsSelected()" [datasource]="valuesList" [minSearchLength]="1" >
  </ng2-completer>`,

  styleUrls: ['./auto-complete-text.component.css']
})

export class AutoCompleteTextComponent implements OnInit {
 
  private keysList : any[];
  private valuesList : any[];

  @Input() keyValuePairs : any;
  //@Input() placeholderYey : any;

  @Output() itemSelectedEvent : EventEmitter<any> = new EventEmitter();

  protected completerService : CompleterService;
  protected dataService : CompleterData;
  
  private searchStr;
  private plh;
 
  constructor(private c: CompleterService) {
    this.completerService = c;

    //this.dataService = c.remote(this.sourceList, 'name' )
    
  }

  ngOnInit(): void {
    this.keysList = Object.keys(this.keyValuePairs);
    this.valuesList = Object.values(this.keyValuePairs);    
  
  }



  itemIsSelected(){
    var selectedKey = Object.keys(this.keyValuePairs).find(key => this.keyValuePairs[key] === this.searchStr);    
    this.itemSelectedEvent.emit({key :selectedKey, value: this.searchStr});
  }

}
