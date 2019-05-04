import { Injectable, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import Core = require("@angular/core");

@Injectable()
export class ImageService {
  visibleImages = [];
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.http = http;
    this.baseUrl = baseUrl;
  }

  getImages(pageNumber: number, pageSize: number, category: string) {
    return this.http.get<ImageMetadata[]>(this.baseUrl + 'api/Image/GetImagesData', {
      params: {
        pageNumber: pageNumber.toString(),
        pageSize: pageSize.toString(),
        category: category
      }
    });
  }

  getImage(id: number, category: string) {
    //return IMAGES.slice(0).find(image => image.id == id)
  }

  getAllCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'api/Image/GetAllCategories');
  }
}
