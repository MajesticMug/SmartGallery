import { Pipe, PipeTransform } from '@angular/core'

@Pipe({name: 'imageFilter'})
export class ImageFilterPipe implements PipeTransform {
  transform(items: any[], criteria: string): any {
    if(criteria === ''){ return items } else
      return items.filter(item =>{
        return item.category.name === criteria;
      });
  }
}
