import React, { useState, useEffect } from "react";
import axios from "../axios/axios2";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Button from "@material-ui/core/Button";
import { makeStyles } from "@material-ui/core/styles";
import Swal from "sweetalert2";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import { TextField,IconButton } from "@material-ui/core";
import { InputAdornment } from "@material-ui/core";

import EventIcon from "@material-ui/icons/Event";
import DialogTitle from "@material-ui/core/DialogTitle";
import { AddCircleOutline, Edit, Delete } from '@material-ui/icons';
import Pagination from '@mui/material/Pagination';
import Navbar from "./Navbar";

const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
  center: {
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  },
});

const App = () => {

  
  const classes = useStyles();
  const [tickets, settickets] = useState([]);
  const [openModal, setOpenModal] = useState(false);
  const [editedTicket, setEditedTicket] = useState({ dateEvent: "", description: "", status: "" });
  const [accion, setAccion] = useState("agregar");
const [editModalOpen, setEditModalOpen] = useState(false);
const [editedTicketId, setEditedTicketId] = useState("");
const [currentPage, setCurrentPage] = useState(1);
const PER_PAGE = 4; 
const indexOfLastticket = currentPage * PER_PAGE;
const indexOfFirstticket = indexOfLastticket - PER_PAGE;
const currentTicket = tickets.slice(indexOfFirstticket, indexOfLastticket);



 // expire token
 const token = localStorage.getItem("access_token");

 axios.interceptors.request.use(
   (config) => {
     config.headers.authorization = `Bearer ${token}`;
     return config;
   },
   (error) => {
     if (error.response.status === 401) {
       localStorage.removeItem("token");
     }
   }
 );
  
  useEffect(() => {
    getTicket();
  }, []);
  const handleAddTicketClick = () => {
    setOpenModal(true);
  };

  const handleCloseModal = () => {
    setOpenModal(false);
  };
  
  const handlePageChange = (event, value) => {
    setCurrentPage(value);
  };

  const getTicket = async () => {
    try {
      const res = await axios.get("/Ticket");
     settickets(res.data); 
    console.log(res);
    } catch (error) {
      console.log(error);
    }
  };

  const addTicket = async () => {
    try {
      await axios.post("/Ticket", editedTicket);
      Swal.fire("ticket agregado", "", "success");
      settickets([...tickets, editedTicket]);
      setEditedTicket({ dateEvent: "", description: "", status: "",eventLocal:"",price:""});
      setOpenModal(false);
    } catch (error) {
      console.log(error);
    }
  };
  

  const eliminarticket = async (id) => {
    console.log(id);
    try {
      await axios.put(`/Ticket/${id}/desactivate`);
      Swal.fire("ticket eliminado", "", "success");
      settickets(tickets.filter((ticket) => ticket.id !== id));
    }
    catch (error) {
      console.log(error);
    }
    
  };

  const actualizarticket = async () => {
    try {
      await axios.put(`/Ticket/${editedTicket.id}`, editedTicket);
      Swal.fire("ticket actualizado", "", "success");
      settickets(
        tickets.map((u) => (u.id === editedTicket.id ? editedTicket : u))
      );
      setAccion("agregar");
      handleCloseEditModal();
    } catch (error) {
      console.log(error);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (accion === "agregar") {
      addTicket();
      getTicket();
    } else {
      actualizarticket();
    }
  };

  // función para abrir el modal de edición
const handleEdit = (id) => {
  setEditedTicket(tickets.find((ticket) => ticket.id === id));
  setEditedTicketId(id);
  setAccion("editar");
  setEditModalOpen(true);
};
const handleCloseEditModal = () => {
  setEditModalOpen(false);
  setEditedTicketId("");
  setEditedTicket({ id: "", dateEvent: "", description: "", status: "" ,localEvent:"",locateEvent:"",price:""});
};
  return (
    <div>
      <Navbar/>
      <form onSubmit={handleSubmit}>
        <h1>Lista de tickets</h1>
        <TableContainer component={Paper}>
        <Table classdescription={classes.table} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Fecha evento</TableCell>
              <TableCell>Descripcion</TableCell>
              <TableCell>stado</TableCell>
              <TableCell>localización del evento</TableCell>
              <TableCell>Precio</TableCell>                   
              <TableCell>Acciones</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {currentTicket.map((ticket, index) => (
              <TableRow key={ticket.id}>
                <TableCell component="th" scope="row">
                  {index + 1 + (currentPage - 1) * PER_PAGE}
                </TableCell>
                <TableCell>{ticket.dateEvent}</TableCell>
                <TableCell>{ticket.description}</TableCell>
                <TableCell>{ticket.status}</TableCell>
                <TableCell>{ticket.locateEvent}</TableCell>
                <TableCell>{ticket.price}</TableCell>
                <TableCell>
                  <Button
                    variant="contained"
                    color="primary"
                    onClick={() => handleEdit(ticket.id)}
                    startIcon={<Edit />}
                  >
                    Editar
                  </Button>{" "}
                  <Button
                    variant="contained"
                    color="secondary"
                    startIcon={<Delete />}
                    onClick={() => eliminarticket(ticket.id)}
                  >
                    Eliminar
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Pagination
        count={Math.ceil(tickets.length / PER_PAGE)}
        page={currentPage}
        onChange={handlePageChange}
        color="primary"
        shape="rounded"
      />
    <Button variant="contained" style={{ backgroundColor: "#4caf50", color: "white" }} onClick={handleAddTicketClick}  startIcon={<AddCircleOutline />}>
        Agregar ticket
      </Button>
      <Dialog open={openModal} onClose={handleCloseModal}>
        <DialogTitle>Agregar ticket</DialogTitle>
        <DialogContent>
        <TextField
  label="Fecha evento"
  type="date"
  value={editedTicket.dateEvent}
  onChange={(e) => setEditedTicket((prev) => ({ ...prev, dateEvent: e.target.value }))} 
  InputProps={{
    inputProps: {
      min: new Date().toISOString().slice(0, 10),
      max: "9999-12-31",
    },
    inputAdornedEnd: true,
    inputAdornment: (
      <IconButton>
        <EventIcon />
      </IconButton>
    ),
    inputComponent: (props) => (
      <input
        {...props}
        pattern="[0-9]{4}-[0-9]{2}-[0-9]{2}"
        placeholder="yyyy-mm-dd"
      />
    ),
  }}
  required
/>

  <br />
  <TextField
    label="Descripción evento"
    type="text"
    value={editedTicket.description}
    onChange={(e) => setEditedTicket({ ...editedTicket, description: e.target.value })}
    required
  />
  <br />
  <TextField
    label="Evento local"
    type="text"
    value={editedTicket.localEvent}
    onChange={(e) => setEditedTicket({ ...editedTicket, localEvent: e.target.value })}
    required
  />
  <br />
  <br />
  <TextField
    label="Localizacion del evento"
    type="text"
    value={editedTicket.locateEvent}
    onChange={(e) => setEditedTicket({ ...editedTicket, locateEvent: e.target.value })}
    required
  />
  <br />
 
  <TextField
    label="Precio"
    type="number"
    value={editedTicket.price}
    onChange={(e) => setEditedTicket({ ...editedTicket, price: e.target.value })}
    required
  />
</DialogContent>
        <DialogActions>
          <Button onClick={handleCloseModal} color="primary">
            Cancelar
          </Button>
          <Button onClick={handleSubmit} color="primary">
            Guardar
          </Button>
        </DialogActions>
      </Dialog>
    </form>
    <Dialog open={editModalOpen} onClose={handleCloseEditModal}>
  <DialogTitle>Editar ticket</DialogTitle>
  <DialogContent>
    <TextField
      label="Fecha evento"
      type="date"
      value={editedTicket.dateEvent}
      onChange={(e) => setEditedTicket((prev) => ({ ...prev, dateEvent: e.target.value }))}
      InputProps={{
        inputProps: {
          min: new Date().toISOString().slice(0, 10),
          max: "9999-12-31T00:00:00.000Z",
        },
        endAdornment: (
          <InputAdornment position="end">
            <IconButton>
              <EventIcon />
            </IconButton>
          </InputAdornment>
        ),
        inputComponent: (props) => (
          <input
            {...props}
            pattern="[0-9]{4}-[0-9]{2}-[0-9]{2}"
            placeholder="yyyy-mm-dd"
          />
        ),
      }}
      required
    />
    <br />
    <TextField
      label="Descripción evento"
      type="text"
      value={editedTicket.description}
      onChange={(e) => setEditedTicket({ ...editedTicket, description: e.target.value })}
      required
    />
    <br />
    <TextField
      label="Evento local"
      type="text"
      value={editedTicket.locateEvent}
      onChange={(e) => setEditedTicket({ ...editedTicket, locateEvent: e.target.value })}
      required
    />
    <br />
    <TextField
      label="Precio"
      type="number"
      value={editedTicket.price}
      onChange={(e) => setEditedTicket({ ...editedTicket, price: e.target.value })}
      required
    />
  </DialogContent>
  <DialogActions>
    <Button onClick={handleCloseEditModal} color="primary">
      Cancelar
    </Button>
    <Button onClick={handleSubmit} color="primary">
      Guardar
    </Button>
  </DialogActions>
</Dialog>
  </div>
  );
}

export default App;