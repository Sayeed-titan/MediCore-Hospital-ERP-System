import { useState, useEffect } from 'react';
import { doctorsApi } from '../../services/api';

function DoctorForm({ doctor, onClose }) {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    specialization: '',
    phone: '',
    email: '',
  });

  useEffect(() => {
    if (doctor) {
      setFormData({
        firstName: doctor.firstName,
        lastName: doctor.lastName,
        specialization: doctor.specialization,
        phone: doctor.phone,
        email: doctor.email,
      });
    }
  }, [doctor]);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      if (doctor) {
        await doctorsApi.update(doctor.id, formData);
        alert('Doctor updated successfully!');
      } else {
        await doctorsApi.create(formData);
        alert('Doctor created successfully!');
      }
      onClose();
    } catch (error) {
      console.error('Error saving doctor:', error);
      alert('Failed to save doctor');
    }
  };

  const specializations = [
    'Cardiology',
    'Pediatrics',
    'Neurology',
    'Orthopedics',
    'Dermatology',
    'Psychiatry',
    'General Medicine',
    'Surgery',
    'ENT',
    'Gynecology',
  ];

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <div className="modal-header">
          <h2>{doctor ? 'Edit Doctor' : 'Add New Doctor'}</h2>
          <button className="close-btn" onClick={onClose}>×</button>
        </div>

        <form onSubmit={handleSubmit}>
          <div className="form-row">
            <div className="form-group">
              <label>First Name *</label>
              <input
                type="text"
                name="firstName"
                value={formData.firstName}
                onChange={handleChange}
                required
              />
            </div>

            <div className="form-group">
              <label>Last Name *</label>
              <input
                type="text"
                name="lastName"
                value={formData.lastName}
                onChange={handleChange}
                required
              />
            </div>
          </div>

          <div className="form-group">
            <label>Specialization *</label>
            <select
              name="specialization"
              value={formData.specialization}
              onChange={handleChange}
              required
            >
              <option value="">Select Specialization</option>
              {specializations.map((spec) => (
                <option key={spec} value={spec}>{spec}</option>
              ))}
            </select>
          </div>

          <div className="form-row">
            <div className="form-group">
              <label>Phone *</label>
              <input
                type="tel"
                name="phone"
                value={formData.phone}
                onChange={handleChange}
                required
              />
            </div>

            <div className="form-group">
              <label>Email *</label>
              <input
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                required
              />
            </div>
          </div>

          <div className="form-actions">
            <button type="button" className="btn-secondary" onClick={onClose}>
              Cancel
            </button>
            <button type="submit" className="btn-primary">
              {doctor ? 'Update' : 'Create'} Doctor
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default DoctorForm;