import { Component, OnInit, Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Core = require("@angular/core");

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  imageData: IImageData = null;
  selectedFile: File = null;
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.http = http;
    this.baseUrl = baseUrl;
    //http.post<IImageData>(baseUrl + 'api/SampleData/WeatherForecasts',
    //{
    //  params: {
    //    fileName: '',
    //    category: '',
    //    imageBytes: '',
    //    description: ''
    //  }
    //  }).subscribe(result => {
    //    this.imageData = result;
    //  },
    //  error => console.error(error));
  }

  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
  }

  uploadImage() {

    const formData = new FormData();

    formData.append('image', this.selectedFile, this.selectedFile.name);

    this.http.post<IImageData>(this.baseUrl + 'api/Image/Upload', formData, {
      params: {
        category: 'testCategory',
        description: 'testDescription'
      }
    })
      .subscribe(resp => console.log(resp));
  }

  ngOnInit() {
  }

}

interface IImageData {
  
}
