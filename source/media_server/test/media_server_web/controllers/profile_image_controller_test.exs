defmodule MediaServerWeb.ProfileImageControllerTest do
  use MediaServerWeb.ConnCase

  alias MediaServer.UserMedia

  @create_attrs %{imagePath: "some imagePath", user: "some user"}
  @update_attrs %{imagePath: "some updated imagePath", user: "some updated user"}
  @invalid_attrs %{imagePath: nil, user: nil}

  def fixture(:profile_image) do
    {:ok, profile_image} = UserMedia.create_profile_image(@create_attrs)
    profile_image
  end

  describe "index" do
    test "lists all profile_image", %{conn: conn} do
      conn = get(conn, Routes.profile_image_path(conn, :index))
      assert html_response(conn, 200) =~ "Listing Profile image"
    end
  end

  describe "new profile_image" do
    test "renders form", %{conn: conn} do
      conn = get(conn, Routes.profile_image_path(conn, :new))
      assert html_response(conn, 200) =~ "New Profile image"
    end
  end

  describe "create profile_image" do
    test "redirects to show when data is valid", %{conn: conn} do
      conn = post(conn, Routes.profile_image_path(conn, :create), profile_image: @create_attrs)

      assert %{id: id} = redirected_params(conn)
      assert redirected_to(conn) == Routes.profile_image_path(conn, :show, id)

      conn = get(conn, Routes.profile_image_path(conn, :show, id))
      assert html_response(conn, 200) =~ "Show Profile image"
    end

    test "renders errors when data is invalid", %{conn: conn} do
      conn = post(conn, Routes.profile_image_path(conn, :create), profile_image: @invalid_attrs)
      assert html_response(conn, 200) =~ "New Profile image"
    end
  end

  describe "edit profile_image" do
    setup [:create_profile_image]

    test "renders form for editing chosen profile_image", %{conn: conn, profile_image: profile_image} do
      conn = get(conn, Routes.profile_image_path(conn, :edit, profile_image))
      assert html_response(conn, 200) =~ "Edit Profile image"
    end
  end

  describe "update profile_image" do
    setup [:create_profile_image]

    test "redirects when data is valid", %{conn: conn, profile_image: profile_image} do
      conn = put(conn, Routes.profile_image_path(conn, :update, profile_image), profile_image: @update_attrs)
      assert redirected_to(conn) == Routes.profile_image_path(conn, :show, profile_image)

      conn = get(conn, Routes.profile_image_path(conn, :show, profile_image))
      assert html_response(conn, 200) =~ "some updated imagePath"
    end

    test "renders errors when data is invalid", %{conn: conn, profile_image: profile_image} do
      conn = put(conn, Routes.profile_image_path(conn, :update, profile_image), profile_image: @invalid_attrs)
      assert html_response(conn, 200) =~ "Edit Profile image"
    end
  end

  describe "delete profile_image" do
    setup [:create_profile_image]

    test "deletes chosen profile_image", %{conn: conn, profile_image: profile_image} do
      conn = delete(conn, Routes.profile_image_path(conn, :delete, profile_image))
      assert redirected_to(conn) == Routes.profile_image_path(conn, :index)
      assert_error_sent 404, fn ->
        get(conn, Routes.profile_image_path(conn, :show, profile_image))
      end
    end
  end

  defp create_profile_image(_) do
    profile_image = fixture(:profile_image)
    %{profile_image: profile_image}
  end
end
