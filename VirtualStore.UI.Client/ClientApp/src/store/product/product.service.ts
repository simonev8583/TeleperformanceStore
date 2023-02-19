import { Product } from "../../models/product/product.model";
import BaseService from "../baseService";

class ProductService extends BaseService {
  private readonly routes = {
    products: "/v1/Product",
    productsOwn: "/v1/Product/Own",
  };

  async getProducts() {
    return this.get(this.routes.products);
  }

  async getProductsOwn() {
    return this.get(this.routes.productsOwn);
  }

  async addProduct(product: Product) {
    return this.post(this.routes.products, product);
  }

  async getProduct(productId: string) {
    const path = `${this.routes.products}/${productId}`;

    return this.get(path);
  }

  async updateProduct(product: Product) {
    const path = `${this.routes.products}/${product.id}`;

    return this.put(path, product);
  }

  async removeProduct(productId: string) {
    const path = `${this.routes.products}/${productId}`;

    return this.delete(path);
  }
}

export default new ProductService();
