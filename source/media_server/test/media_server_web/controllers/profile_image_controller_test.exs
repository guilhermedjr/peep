defmodule MediaServerWeb.ProfileImageControllerTest do
  use MediaServerWeb.ConnCase

  alias MediaServer.ProfileImages
  alias MediaServer.ProfileImages.ProfileImage

  @create_attrs %{
    image: "some image",
    user: "7488a646-e31f-11e4-aace-600308960662"
  }
  @update_attrs %{
    image: "some updated image",
    user: "7488a646-e31f-11e4-aace-600308960668"
  }
  @invalid_attrs %{image: nil, user: nil}

  def fixture(:profile_image) do
    {:ok, profile_image} = ProfileImages.create_profile_image(@create_attrs)
    profile_image
  end

  setup %{conn: conn} do
    {:ok, conn: put_req_header(conn, "accept", "application/json")}
  end

  describe "index" do
    test "lists all profile_image", %{conn: conn} do
      conn = get(conn, Routes.profile_image_path(conn, :index))
      assert json_response(conn, 200)["data"] == []
    end
  end

  describe "create profile_image" do
    test "renders profile_image when data is valid", %{conn: conn} do
      conn = post(conn, Routes.profile_image_path(conn, :create), profile_image: @create_attrs)
      assert %{"id" => id} = json_response(conn, 201)["data"]

      conn = get(conn, Routes.profile_image_path(conn, :show, id))

      assert %{
               "id" => id,
               "image" => "some image",
               "user" => "7488a646-e31f-11e4-aace-600308960662"
             } = json_response(conn, 200)["data"]
    end

    test "renders errors when data is invalid", %{conn: conn} do
      conn = post(conn, Routes.profile_image_path(conn, :create), profile_image: @invalid_attrs)
      assert json_response(conn, 422)["errors"] != %{}
    end
  end

  describe "update profile_image" do
    setup [:create_profile_image]

    test "renders profile_image when data is valid", %{conn: conn, profile_image: %ProfileImage{id: id} = profile_image} do
      conn = put(conn, Routes.profile_image_path(conn, :update, profile_image), profile_image: @update_attrs)
      assert %{"id" => ^id} = json_response(conn, 200)["data"]

      conn = get(conn, Routes.profile_image_path(conn, :show, id))

      assert %{
               "id" => id,
               "image" => "some updated image",
               "user" => "7488a646-e31f-11e4-aace-600308960668"
             } = json_response(conn, 200)["data"]
    end

    test "renders errors when data is invalid", %{conn: conn, profile_image: profile_image} do
      conn = put(conn, Routes.profile_image_path(conn, :update, profile_image), profile_image: @invalid_attrs)
      assert json_response(conn, 422)["errors"] != %{}
    end
  end

  describe "delete profile_image" do
    setup [:create_profile_image]

    test "deletes chosen profile_image", %{conn: conn, profile_image: profile_image} do
      conn = delete(conn, Routes.profile_image_path(conn, :delete, profile_image))
      assert response(conn, 204)

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
