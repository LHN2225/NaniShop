import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";

import { FunnelFill } from "react-bootstrap-icons";
import { Table, Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, Form, FormGroup } from 'reactstrap';

import { Link } from "react-router-dom";

import { getCategoriesRequest, DeleteCategoryRequest  } from "../services/request"
import { CATEGORY, CREATE_CATEGORY, EDIT_CATEGORY } from '../../../Constants/pages';

import MyVerticallyCenteredModal from "../categoryFrom"



const ListCategory = () => {


  const [categories, setCategories] = useState("");
  const [toggle, setToggle] = useState(true);
  /*const fetchDataCallbackAsync = async () =>  {
    let data = await getBrandsRequest(query);
    console.log('fetchDataCallbackAsync');
    console.log(data);
    setCategories(data);
  }*/

  const [modalShow, setModalShow] = useState(false);
  const [doRefresh, setRefresh] = useState(false);
  const [tempCategory, setTempCategory] = useState(null);

  /*const handleRefresh = (doRefresh) => {
    //setModalShow(false);
    if (doRefresh) {
      setToggle(!toggle);
      console.log("Refresh calling "+ toggle);
      //setRefresh(false);
      doRefresh = false;
    }
  }{id: "123", name: "abc"}*/

  useEffect(() => {
    console.log("Refresh calling");
  }, [toggle]);



  useEffect(() => {
      setModalShow(false);
      setToggle(!toggle);
      getCategoriesRequest().then(response => setCategories(response));
      setTempCategory(null);
  }, [doRefresh]);

  function handleEdit(data) {
    setModalShow(true);
    setTempCategory(data);
    console.log("sending ");
    console.log(tempCategory);
  }

  function openModal(data) {
    console.log("Opening Modal");
    setModalShow(true);
    return (
      <MyVerticallyCenteredModal
        isShown={modalShow}
        onHide={() => setModalShow(false)}
        onRefresh={() => setRefresh(!doRefresh)}
        initialCategoryForm={data}
      />
    )
  }

  function handleDelete(categoryID) {
    DeleteCategoryRequest(categoryID);
    setRefresh(!doRefresh)
  }

  return (
    <>
      <div className="primaryColor text-title intro-x">Category List</div>

      <div className="d-flex mb-5 intro-x">
            <div className="d-flex align-items-center ml-3">
              <Button variant="primary" color="success" onClick={e => setModalShow(true)}>Create new category</Button>
            </div>
      </div>
      <MyVerticallyCenteredModal
        isShown={modalShow}
        onHide={() => setModalShow(false)}
        onRefresh={() => setRefresh(!doRefresh)}
        initialCategoryForm={tempCategory}
      />
      <Table>
      <thead>
        <tr>
          <th>Category ID</th>
          <th>Category Name</th>
        </tr>
      </thead>
      <tbody>
      {categories ? categories.data.map((data, index) => (data.isDeleted === false) ?
      (<tr key={index}>
        <td>{data.id}</td>
        <td>{data.name}</td>
        <td className="d-flex">
        <Button color="warning" onClick={e => handleEdit(data)} >Edit</Button>
        <Button color="danger" onClick={e => handleDelete(data.id)}>Delete</Button>
        </td>
      </tr>) : null) : null}
      </tbody>
    </Table>
    </>
  );
};

export default ListCategory;
