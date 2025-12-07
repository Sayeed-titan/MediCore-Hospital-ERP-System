const API_BASE_URL = 'http://localhost:5099/api';

// Generic API call function
const apiCall = async (endpoint, options = {}) => {
  try {
    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
      headers: {
        'Content-Type': 'application/json',
        ...options.headers,
      },
      ...options,
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    // For DELETE requests that return 204 No Content
    if (response.status === 204) {
      return null;
    }

    return await response.json();
  } catch (error) {
    console.error('API call error:', error);
    throw error;
  }
};

// Patients API
export const patientsApi = {
  getAll: () => apiCall('/patients'),
  getById: (id) => apiCall(`/patients/${id}`),
  create: (patient) => apiCall('/patients', {
    method: 'POST',
    body: JSON.stringify(patient),
  }),
  update: (id, patient) => apiCall(`/patients/${id}`, {
    method: 'PUT',
    body: JSON.stringify(patient),
  }),
  delete: (id) => apiCall(`/patients/${id}`, { method: 'DELETE' }),
};

// Doctors API
export const doctorsApi = {
  getAll: () => apiCall('/doctors'),
  getById: (id) => apiCall(`/doctors/${id}`),
  create: (doctor) => apiCall('/doctors', {
    method: 'POST',
    body: JSON.stringify(doctor),
  }),
  update: (id, doctor) => apiCall(`/doctors/${id}`, {
    method: 'PUT',
    body: JSON.stringify(doctor),
  }),
  delete: (id) => apiCall(`/doctors/${id}`, { method: 'DELETE' }),
};

// Appointments API
export const appointmentsApi = {
  getAll: () => apiCall('/appointments'),
  getById: (id) => apiCall(`/appointments/${id}`),
  create: (appointment) => apiCall('/appointments', {
    method: 'POST',
    body: JSON.stringify(appointment),
  }),
  updateStatus: (id, status) => apiCall(`/appointments/${id}/status`, {
    method: 'PATCH',
    body: JSON.stringify({ status }),
  }),
  delete: (id) => apiCall(`/appointments/${id}`, { method: 'DELETE' }),
  getStats: () => apiCall('/appointments/stats'),
};