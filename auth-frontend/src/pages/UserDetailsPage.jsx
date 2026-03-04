import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getUserDetails } from "../api/authService";
import { useAuth } from "../context/useAuth";

export default function UserDetailsPage() {
  const navigate = useNavigate();
  const { logout } = useAuth();

  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    async function fetchUser() {
      try {
        const data = await getUserDetails();
        setUser(data);
      } catch {
        setError("Failed to load user details.");
      }
    }

    fetchUser();
  }, []);

  function handleLogout() {
    logout();
    navigate("/login");
  }

  if (error) {
    return (
      <div className="min-h-screen flex items-center justify-center">
        <p className="text-red-500">{error}</p>
      </div>
    );
  }

  if (!user) {
    return (
      <div className="min-h-screen flex items-center justify-center">
        <p>Loading user...</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <div className="bg-white p-8 rounded shadow w-full max-w-sm">
        <h1 className="text-2xl font-semibold mb-6 text-center">
          User Details
        </h1>

        <div className="space-y-3 mb-6">
          <p>
            <strong>First Name:</strong> {user.firstName}
          </p>

          <p>
            <strong>Last Name:</strong> {user.lastName}
          </p>

          <p>
            <strong>Email:</strong> {user.email}
          </p>
        </div>

        <button
          onClick={handleLogout}
          className="w-full bg-red-600 text-white p-2 rounded hover:bg-red-700"
        >
          Logout
        </button>
      </div>
    </div>
  );
}
