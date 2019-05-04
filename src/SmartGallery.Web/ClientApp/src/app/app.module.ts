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

import { UploadComponent } from "./upload/upload.component";
import { GalleryComponent } from "./gallery/gallery.component";
import { ImageFilterPipe } from "./core/pipes/image-filter.pipe";
import { ImageService } from "./image.service"

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UploadComponent,
    GalleryComponent,
    ImageFilterPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: GalleryComponent, pathMatch: 'full' },
      { path: 'upload', component: UploadComponent }
    ])
  ],
  providers: [ImageService, ImageFilterPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
