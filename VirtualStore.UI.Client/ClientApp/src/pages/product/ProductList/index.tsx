import React, { Fragment, useEffect } from "react";
import { useProduct } from "../../../hooks/useProduct";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";

const ProductListPage = () => {
  const { productsOwn, getProductsOwn, removeProduct } = useProduct();

  useEffect(() => {
    getProductsOwn();
  }, []);

  const deleteProduct = (id: string) => {
    removeProduct(id);

    setTimeout(() => {
      getProductsOwn();
    }, 1000);
  };

  return (
    <Fragment>
      <div>
        <Link to="products/create" className="btn btn-primary">
          Agregar producto
        </Link>
      </div>
      <Table>
        <thead>
          <tr>
            <th>Titulo</th>
            <th>Descripción</th>
            <th>Precio</th>
            <th>Stock</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {productsOwn.map((product) => (
            <tr key={product.id}>
              <td>{product.title}</td>
              <td>{product.description}</td>
              <td>{product.price}</td>
              <td>{product.stock}</td>
              <td>
                <Link
                  to={`products/edit/${product.id}`}
                  className="btn btn-primary"
                >
                  Editar
                </Link>
                <Button
                  color="warning"
                  onClick={() => deleteProduct(product.id)}
                >
                  Eliminar
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </Fragment>
  );
};

export default ProductListPage;
