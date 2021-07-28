import { Formik, Form, ErrorMessage, Field } from 'formik';
import React, { useState, useEffect } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input , Label, FormGroup } from 'reactstrap';
import { UpdateCategoryRequest, createCategoryRequest } from "./services/request"
import * as Yup from 'yup';
import TextField from '../../shared-components/FormInputs/TextField';


const initialFormValues = {
    id: '',
    name: '',
};

const validationSchema = Yup.object().shape({
    id: Yup.string(),
    name: Yup.string().required('Required'),
});

const MyVerticallyCenteredModal =  (props) => {

    const {
      isShown,
      buttonLabel,
      className,
      initialCategoryForm
    } = props;
  
    const [data, setData] = useState({
        id: '',
        name: '',
    });
    const [isUpdate, setUpdate] = useState(false);
    const [modal, setModal] = useState(isShown);
    const [unmountOnClose, setUnmountOnClose] = useState(true);
  
    const toggle = () => setModal(!modal);
    const changeUnmountOnClose = e => {
        let value = e.target.value;
        setUnmountOnClose(JSON.parse(value));
    }
    
    function handleSubmit() {
        console.log("Submitting");
        console.log(data);
        //event.preventDefault();
        if (isUpdate === false) {
            createCategoryRequest(data);
        }
        else {
            setUpdate(false);
            UpdateCategoryRequest(data);
        }
    }

    function handleChange(event) {
        var target = event.target;
        var name = target.name;
        var value = target.value;
        setData({ ...data, [name] : value });
    }


    useEffect(() => {
        setModal(isShown);
        setData(initialCategoryForm ? initialCategoryForm: initialFormValues);
        setUpdate(initialCategoryForm ? true : false);
        console.log(data);
        console.log(initialCategoryForm);

    }, [isShown]);

    return (
        /*<div>
            <Modal isOpen={modal} toggle={toggle} className={className} centered>
                        {(isUpdate === false) ? (<ModalHeader >Add Category</ModalHeader>) : <ModalHeader >Edit Category</ModalHeader>}
                
                        <form
                            onSubmit={(e) => handleSubmit(e)}
                        >
                                    <ModalBody>
                                        <Input type="text" name="name" onChange={(e) => handleChange(e)} placeholder="Category name" rows={5} />
                                    </ModalBody>
                                    <ModalFooter>
                                        <Button color="primary" type="submit">Send</Button>
                                        <Button color="secondary" onClick={props.onHide}>Cancel</Button>
                                    </ModalFooter>
                        </form>
            </Modal>
        </div>*/

        <div>
             <Modal isOpen={modal} toggle={props.onHide} className={className} centered>
                        {(isUpdate === false) ? (<ModalHeader >Add Category</ModalHeader>) : (<ModalHeader >Edit Category</ModalHeader>)}
                
                <Formik
                initialValues={data}
                enableReinitialize
                validationSchema={validationSchema}

                onSubmit={values => {
                    handleSubmit()
                    setData(initialFormValues);
                    setUpdate(false);
                    props.onRefresh();
                  }}/*{e => handleSubmit()}*/
                    
                >
                    {({ errors, touched }) => (
                        <Form>
                                    <ModalBody>
                                        <TextField name="name" label="Category name:" onChange={e => handleChange(e)} value={data ? data.name : ""} rows={5} />
                                    </ModalBody>
                                    <ModalFooter>
                                        <Button color="primary" type="submit">Send</Button>
                                        <Button color="secondary" onClick={props.onHide}>Cancel</Button>
                                    </ModalFooter>
                        </Form>
                    )}
                </Formik>
            </Modal>
        </div>
    );
}

export default MyVerticallyCenteredModal;

/*import React, { useState } from 'react';
import { Table, Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, Form, FormGroup } from 'reactstrap';

function MyVerticallyCenteredModal(props) {
    console.log("Modal was triggered");
    return (
      <Modal
        {...props}
        isOpen={props.show}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Modal heading
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <h4>Centered Modal</h4>
          <p>
            Cras mattis consectetur purus sit amet fermentum. Cras justo odio,
            dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac
            consectetur ac, vestibulum at eros.
          </p>
        </Modal.Body>
        <Modal.Footer>
          <Button onClick={props.onHide}>Close</Button>
        </Modal.Footer>
      </Modal>
    );
  }*/