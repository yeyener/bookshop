import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'app-modal-check-box',
  templateUrl: './modal-check-box.component.html',
  styleUrls: ['./modal-check-box.component.css']
})
export class ModalCheckBoxComponent implements OnInit {

  private modalData: any = {};

  @Input() allItemsParam: any;
  @Input() selectedItemsOnOpenParam: any;

  @Output() saveEvent: EventEmitter<any> = new EventEmitter();

  constructor(private ngxSmartModalService: NgxSmartModalService) { }

  ngOnInit() {
    this.modalData.all = {};
  }

  showGenres() {
    this.ngxSmartModalService.getModal('chckBoxModel').open();
    this.modalData.all = this.allItemsParam;
    this.modalData.current = this.selectedItemsOnOpenParam;

    if (this.modalData !== null ) {
      this.modalData.all.forEach(elementOfBig => {
        elementOfBig.checked = false;
        this.modalData.current.forEach(elementOfSmall => {
          if (elementOfBig.id === elementOfSmall.id) {
            elementOfBig.checked = true;
          }
        });
      });
    }

    this.ngxSmartModalService.setModalData(this.modalData, 'chckBoxModel', true);
  }


  onSave() {
    this.saveEvent.emit({selected : this.ngxSmartModalService.getModalData('chckBoxModel').all.filter(a => a.checked)});
    this.ngxSmartModalService.getModal('chckBoxModel').close();
  }

  cleanData() {
    this.ngxSmartModalService.resetModalData('chckBoxModel');
  }

}
