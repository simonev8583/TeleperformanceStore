import axios from "axios";
import { Product } from "../../models/product/product.model";
import BaseService from "../baseService";

class ProductService extends BaseService {
  private readonly routes = {
    products: "/v1/Product",
    productsOwn: "/v1/Product/Own",
    productImage: "/v1/Product/Image",
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

  async uploadImage(image: File, productId: string) {
    const headers = this.getHeaders();
    headers["Content-Type"] = "multipart/form-data";

    const formData = new FormData();

    formData.append("File", image);
    formData.append("productId", productId);

    return axios.post(`${this.baseApi}${this.routes.productImage}`, formData, {
      headers: headers,
    });
  }

  async getImage(filename: string) {
    const headers = this.getHeaders();
    headers["Content-Type"] = "multipart/form-data";

    return this.get(`${this.routes.productImage}?filekey=${filename}`);
  }
}

export default new ProductService();
