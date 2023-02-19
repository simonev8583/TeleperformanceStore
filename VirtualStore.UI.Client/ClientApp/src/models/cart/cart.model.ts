import { Product } from "../product/product.model";

export interface Cart {
  id: string;
  personId: string;
  products: Product[];
}
