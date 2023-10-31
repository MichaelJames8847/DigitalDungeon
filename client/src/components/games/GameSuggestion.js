import { useState } from "react";
import { suggestGame } from "../../managers/gameManager";
import { Button, Form, FormGroup, Input, Label, Modal, ModalBody, ModalHeader } from "reactstrap";
import "./GameSuggestion.css"
import { useNavigate } from "react-router-dom";

export default function GameSuggestion() {
    const [title, setTitle] = useState("");
    const [modalOpen, setModalOpen] = useState(false);
    const [modalMessage, setModalMessage] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async () => {
        try {
            const data = await suggestGame(title);
            
            if (data && data.Id) { 
                setModalMessage("Your suggestion is pending approval. You will be notified once the admins review it.");
                setTitle("");
            } else {
                setModalMessage(data.message || "An error occurred. Please try again.");
            }
        } catch (error) {
            setModalMessage("An error occurred. Please try again.");
        }

        setModalOpen(true);

        setTimeout(() => {
            setModalOpen(false);
            navigate("/");
        }, 3000);
    };

    return (
        <div className="game-suggestion">
            <Form onSubmit={e => { e.preventDefault(); handleSubmit(); }}>
                <FormGroup>
                    <Label for="gameTitle">Game Title</Label>
                    <Input type="text" name="title" id="gameTitle" placeholder="Enter game title" value={title} onChange={e => setTitle(e.target.value)} required />
                </FormGroup>
                <Button color="primary" type="submit">Submit Suggestion</Button>
            </Form>
            <Modal isOpen={modalOpen} toggle={() => setModalOpen(false)}>
                <ModalHeader toggle={() => setModalOpen(false)}>Notification</ModalHeader>
                <ModalBody>
                    {modalMessage}
                </ModalBody>
            </Modal>
        </div>
    );
}
