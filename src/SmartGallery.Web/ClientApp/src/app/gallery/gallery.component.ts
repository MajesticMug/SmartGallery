import { Component, OnInit, OnChanges } from '@angular/core';
import { ImageService } from "../image.service"

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit, OnChanges {

  imageService: ImageService;

  visibleImages: ImageMetadata[] = [];

  categories: Category[];
  selectedCategory: string = '';

  pageNumber: number = 1;
  pageSize: number = 20;

  constructor(imageService: ImageService) {
    this.imageService = imageService;
  }

  ngOnInit() {
    this.imageService.getAllCategories().subscribe(categories => this.categories = categories);

    this.loadImages();
  }

  ngOnChanges() {
    this.loadImages();
  }

  loadImages() {
    this.imageService.getImages(this.pageNumber, this.pageSize, this.selectedCategory)
      .subscribe(imageDataList => this.visibleImages = imageDataList);
  }

}
