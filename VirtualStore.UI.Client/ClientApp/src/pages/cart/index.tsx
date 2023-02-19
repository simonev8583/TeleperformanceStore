import { Cart } from "../../models/cart/cart.model";
import { Alert, Button, Card, CardBody, Table } from "reactstrap";
import React, { Fragment, useEffect, useState } from "react";
import { useCart } from "../../hooks/useCart";

interface PropTypes {
  cart: Cart;
}

const CartPage = (props: PropTypes) => {
  const [message, setMessage] = useState<string>("");
  const [total, setTotal] = useState<number>(0);

  const { updateCart } = useCart();

  const { cart } = props;

  useEffect(() => {
    calculateTotal();
  });

  const addQuantity = (productId: string) => {
    const cartCloned: Cart = JSON.parse(JSON.stringify(cart));

    const product = cartCloned.products.filter((p) => p.id === productId)[0];

    if (product.quantity + 1 > product.stock) {
      setMessage("No hay suficientes cantidades disponibles para agregar");

      setTimeout(() => {
        setMessage("");
      }, 2000);

      return;
    }

    product.quantity += 1;

    updateCart(cartCloned);
  };

  const subtractQuantity = (productId: string) => {
    const cartCloned: Cart = JSON.parse(JSON.stringify(cart));

    const product = cartCloned.products.filter((p) => p.id === productId)[0];

    if (product.quantity - 1 <= 0) {
      setMessage("Se va a retirar el producto de su carrito");

      setTimeout(() => {
        setMessage("");
      }, 3000);

      const index = cartCloned.products.indexOf(product);

      cartCloned.products.splice(index, 1);

      updateCart(cartCloned);

      return;
    }

    product.quantity -= 1;

    updateCart(cartCloned);
  };

  const calculateTotal = () => {
    let sum = 0;

    if (!cart) return;

    cart.products.forEach((product) => {
      sum += product.quantity * product.price;
    });

    setTotal(sum);
  };

  return (
    <Fragment>
      {message && <Alert color="warning">{message}</Alert>}
      <Card>
        <h2>Mi carrito</h2>

        <CardBody>
          <Table>
            <tbody>
              {cart &&
                cart.products.map((product) => (
                  <tr key={product.id}>
                    <td>{product.title}</td>
                    <td>{product.price}</td>
                    <td>{product.quantity}</td>
                    <td>
                      <Button
                        color="warning"
                        onClick={() => subtractQuantity(product.id)}
                      >
                        -
                      </Button>{" "}
                      <Button
                        color="primary"
                        onClick={() => addQuantity(product.id)}
                      >
                        +
                      </Button>
                    </td>
                  </tr>
                ))}
              <tr>
                <td colSpan={2}></td>
                <td>Total:</td>
                <td>{total}</td>
              </tr>
            </tbody>
          </Table>
        </CardBody>
      </Card>
    </Fragment>
  );
};

export default CartPage;
