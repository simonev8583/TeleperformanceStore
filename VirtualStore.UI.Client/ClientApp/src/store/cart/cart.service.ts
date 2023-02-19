import { Cart } from "../../models/cart/cart.model";
import BaseService from "../baseService";

class CartService extends BaseService {
  private readonly routes = {
    cart: "/v1/Cart",
  };

  async getCart() {
    return this.get(this.routes.cart);
  }

  async updateCart(cart: Cart) {
    return this.put(this.routes.cart, cart);
  }
}

export default new CartService();
