import cartSelector from "../store/cart/cart.selector";
import { useDispatch, useSelector } from "react-redux";
import cartAction from "../store/cart/cart.action";
import { Cart } from "../models/cart/cart.model";

export const useCart = () => {
  const cart: Cart = useSelector(cartSelector.getCart);

  const dispatch = useDispatch();

  const getCart = () => {
    dispatch(cartAction.getCartAction());
  };

  const updateCart = (cart: Cart) => {
    dispatch(cartAction.updateCartAction(cart));
  };

  return {
    cart,
    getCart,
    updateCart,
  };
};
