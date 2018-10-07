import { BookdefService } from './services/bookdef.service';
import { WriterFormComponent } from './components/writer-form/writer-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { WriterService } from './services/writer.service';
import { BookdefFormComponent } from './components/bookdef-form/bookdef-form.component';
import { AutoCompleteTextComponent } from './components/auto-complete-text/auto-complete-text.component';
import { Ng2CompleterModule } from 'ng2-completer';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    WriterFormComponent,
    BookdefFormComponent,
    AutoCompleteTextComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    Ng2CompleterModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'writer-form', component: WriterFormComponent },
      { path: 'bookdef-form', component: BookdefFormComponent },
    ])
  ],
  providers: [WriterService, BookdefService],
  bootstrap: [AppComponent]
})
export class AppModule { }
